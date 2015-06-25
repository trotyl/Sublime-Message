﻿using SublimeMessage.Carriers.Results;
using SublimeMessage.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SublimeMessage.Enums;
using SublimeMessage.AsyncStates;

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

        private static Dictionary<string, User> m_usersDic = new Dictionary<string, User>
        {
            ["111111"] = new User { Name = "Alice", Id = "111111", HasMessage = false },
            ["222222"] = new User { Name = "Bob", Id = "222222", HasMessage = false },
            ["333333"] = new User { Name = "Cindy", Id = "333333", HasMessage = true },
        };
        private static Dictionary<string, List<Message>> m_userMessagesDic = new Dictionary<string, List<Message>> { };
        private static Dictionary<string, List<Message>> m_groupMessagesDic = new Dictionary<string, List<Message>> { };
        private static Dictionary<string, Action<Message>> m_messageCallbackDic = new Dictionary<string, Action<Message>> { };

        public static Action<User> UserOnline;
        public static Action<User> UserOffline;
        public static Action<User> NewMessage;

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

        public static void RetriveMessages(EntityType type, string id, Action<Message> callback)
        {
            if(type == EntityType.User)
            {
                if(!m_userMessagesDic.ContainsKey(id))
                {
                    m_userMessagesDic[id] = new List<Message>();
                }
                Array.ForEach(m_userMessagesDic[id].ToArray(), callback);
            }
            else
            {
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
            m_usersDic["222222"].HasMessage = true;
            m_usersDic["222222"].HasMessage = true;
            m_usersDic["333333"].HasMessage = false;
            m_usersDic["333333"].HasMessage = false;
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
