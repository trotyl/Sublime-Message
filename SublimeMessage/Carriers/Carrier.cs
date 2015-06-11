using SublimeMessage.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeMessage.Carriers
{
    public static class Carrier
    {
        public static async Task<Tuple<bool, int, string>> SendRegisterRequest(string username, string mail, string password)
        {
            var task = new Task<Tuple<bool, int, string>>(m_sendRegisterRequest, new Tuple<string, string, string>(username, mail, password));
            task.Start();
            return await task;
        }

        public static async Task<LoginResult> SendLoginRequest(string username, string password)
        {
            var task = new Task<LoginResult>(m_sendLoginRequest, new Tuple<string, string>(username, password));
            task.Start();
            return await task;
        }

        public static async Task<Tuple<bool, int, IEnumerable<string>>> SendUserListRequest()
        {
            var task = new Task<Tuple<bool, int, IEnumerable<string>>>(_sendUserListRequest, null);
            task.Start();
            return await task;
        }

        private static Tuple<bool, int, IEnumerable<string>> _sendUserListRequest(object arg)
        {
            return new Tuple<bool, int, IEnumerable<string>>(true, 200, new List<string>
            {
                "余泽江（11111111）：在线",
                "泽江余（22222222）：在线",
                "江余泽（11111111）：在线",
                "余江泽（11111111）：在线",
                "江泽余（11111111）：在线",
                "泽余江（11111111）：在线",
            });
        }


        private static Tuple<bool, int, string> m_sendRegisterRequest(object state)
        {
            throw new NotImplementedException();
        }

        private static LoginResult m_sendLoginRequest(object state)
        {
            throw new NotImplementedException();
        }

    }
}
