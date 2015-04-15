using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeMessage.Helpers
{
    public class Carrier
    {
        public async Task<Tuple<bool, int, string>> SendRegisterRequest(string name, string mail, string password)
        {
            return await new Task<Tuple<bool, int, string>>(_sendRegisterRequest, new Tuple<string, string, string>(name, mail, password));
        }

        public async Task<Tuple<bool, int>> SendLoginRequest(string identifier, string password)
        {
            var task = new Task<Tuple<bool, int>>(_sendLoginRequest, new Tuple<string, string>(identifier, password));
            task.Start();
            return await task;
        }

        
        private Tuple<bool, int, string> _sendRegisterRequest(object state)
        {
            throw new NotImplementedException();
        }
        
        private Tuple<bool, int> _sendLoginRequest(object state)
        {
            var tuple = (Tuple<string, string>)state;
            return new Tuple<bool, int>(true, tuple.Item1.Length);
        }

    }
}
