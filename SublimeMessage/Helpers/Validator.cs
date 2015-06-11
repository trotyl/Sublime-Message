using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeMessage.Helpers
{
    public class Validator
    {
        public static void ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("用户名不能为空或空白字符！");
            }
        }

        public static void ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("密码不能为空！");
            }
        }
    }
}
