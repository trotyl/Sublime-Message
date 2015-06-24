using SublimeMessage.Carriers.Results;
using SublimeMessage.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SublimeMessage.Enums;

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

        private static Dictionary<string, List<Message>> m_userMessagesDic;
        private static Dictionary<string, List<Message>> m_groupMessagesDic;

        public static async Task<RegesterResult> Regester(string username, string mail, string password)
        {
            var task = new Task<RegesterResult>(m_sendRegisterRequest, new RegesterResult());
            task.Start();
            return await task;
        }

        public static async Task<LoginResult> Login(string username, string password)
        {
            Mode = CarrierMode.Server;

            var task = new Task<LoginResult>(m_sendLoginRequest, new LoginResult());
            task.Start();
            return await task;
        }

        internal static IEnumerable<Message> RetriveMessages(EntityType type, string id)
        {
            if(type == EntityType.User)
            {
                return m_userMessagesDic.ContainsKey(id) ? m_userMessagesDic[id] : new List<Message>();
            }
            else
            {
                return m_groupMessagesDic.ContainsKey(id) ? m_groupMessagesDic[id] : new List<Message>();
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
                Users = new List<User>
                {
                    new User { Name = "Alice", Id = "111111", HasMessage = false },
                    new User { Name = "Bob", Id = "222222", HasMessage = false },
                    new User { Name = "Cindy", Id = "333333", HasMessage = true },
                }
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

        private static GetUsersResult m_getUsers(object arg)
        {
            throw new NotImplementedException();
        }


        private static RegesterResult m_sendRegisterRequest(object state)
        {
            throw new NotImplementedException();
        }

        private static LoginResult m_sendLoginRequest(object state)
        {
            throw new NotImplementedException();
        }

    }
}
