using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public static void ValidateEmail(string email)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(email);
            if (string.IsNullOrEmpty(email) || !match.Success)
            {
                throw new ArgumentException("电子邮件地址格式不正确！");
            }
        }

        public static void ValidateEquality(string first, string second)
        {
            if (string.Compare(first, second) != 0)
            {
                throw new ArgumentException("两次输入的密码不匹配！");
            }
        }
    }
}
