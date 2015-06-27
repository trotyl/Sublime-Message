using SublimeMessage.Carriers.Results;
using SublimeMessage.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SublimeMessage.Enums;
using SublimeMessage.AsyncStates;
using TctpUtil;
using System.Threading;
using Newtonsoft.Json;

namespace SublimeMessage.Carriers
{
    public enum CarrierMode
    {
        Server,
        Ptop
    }

    public static class Carrier
    {
        public static CarrierMode Mode { get; private set; }
        private static TctpClient m_client;
        private static int m_count;
        
        private static Dictionary<string, User> m_usersDic;
        private static Dictionary<string, List<Message>> m_userMessagesDic;
        private static Dictionary<string, List<Message>> m_groupMessagesDic;
        private static Dictionary<string, Action<Message>> m_userCallbackDic;
        private static Dictionary<string, Action<Message>> m_groupCallbackDic;
        private static Dictionary<int, Task> m_requestCallbackDic;

        public static Action<User> OnUserOnline;
        public static Action<User> OnUserOffline;
        public static Action<User> OnNewMessage;

        static Carrier()
        {
            m_client = new TctpClient();
            m_count = 0;

            m_usersDic = new Dictionary<string, User> { };
            m_userMessagesDic = new Dictionary<string, List<Message>> { };
            m_groupMessagesDic = new Dictionary<string, List<Message>> { };
            m_userCallbackDic = new Dictionary<string, Action<Message>> { };
            m_groupCallbackDic = new Dictionary<string, Action<Message>> { };
            m_requestCallbackDic = new Dictionary<int, Task> { };

            m_client.OnReceive = x =>
            {
                var message = JsonConvert.DeserializeObject<dynamic>(x);
                DealWith(message);
                return;
            };
        }

        private static void DealWith(dynamic message)
        {
            var typeString = message.Type as string ?? "";
            var types = typeString.Split('.');
            var index = (int)(message.Index);
            switch (types[0])
            {
                case "Control":
                    if(m_requestCallbackDic.ContainsKey(index))
                    {
                        m_requestCallbackDic[index].Start();
                    }
                    break;
                default:
                    break;
            }
        }

        public static async Task<RegesterResult> Regester(string username, string mail, string password)
        {
            var task = new Task<RegesterResult>(m_registerRequestDummy, new RegesterResult());
            var messageId = unchecked(Interlocked.Increment(ref m_count));
            return await task;
        }

        public static async Task<LoginResult> Login(string username, string password)
        {
            Mode = CarrierMode.Server;

            var task = new Task<LoginResult>(m_sendLoginRequest, new LoginResult());
            task.Start();
            return await task;
        }

        public static void RetriveMessages(EntityType type, string id, Action<Message> callback)
        {
            if(type == EntityType.User)
            {
                m_userCallbackDic[id] = callback;
                if(!m_userMessagesDic.ContainsKey(id))
                {
                    m_userMessagesDic[id] = new List<Message>();
                }
                Array.ForEach(m_userMessagesDic[id].ToArray(), callback);
            }
            else
            {
                m_groupCallbackDic[id] = callback;
                if (!m_groupMessagesDic.ContainsKey(id))
                {
                    m_groupMessagesDic[id] = new List<Message>();
                }
                Array.ForEach(m_groupMessagesDic[id].ToArray(), callback);
            }
        }

        public static async Task<InitResult> InitPtop(string username)
        {
            Mode = CarrierMode.Ptop;

            throw new NotImplementedException();
        }

        public static async Task<GetUsersResult> GetUsers()
        {
            return new GetUsersResult
            {
                HasError = false,
                StatusCode = 200,
                Message = "",
                Users = m_usersDic.Values.ToArray()
            };
        }

        public static async Task<GetGroupsResult> GetGroups()
        {
            return new GetGroupsResult
            {
                HasError = false,
                StatusCode = 200,
                Message = "",
                Groups = new List<Group>(),
            };
        }


        public static async Task<AddFriendResult> AddFriend(string id)
        {
            return new AddFriendResult
            {
                HasError = false,
                StatusCode = 200,
                Message = "",
                User = new User
                {
                    Id = "444444",
                    Name = "Dave",
                    HasMessage = false,
                },
            };
        }

        internal static void Test()
        {
            
        }

        private static GetUsersResult m_getUsers(object arg)
        {
            throw new NotImplementedException();
        }


        private static RegesterResult m_registerRequestDummy(object state)
        {
            throw new NotImplementedException();
        }

        private static LoginResult m_sendLoginRequest(object state)
        {
            throw new NotImplementedException();
        }

    }
}
