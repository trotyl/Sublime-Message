using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeMessage.Carriers.Exceptions
{
    public class LoginFailedException : Exception
    {
        public LoginFailedException(string message) : base(message) { }
    }
}
