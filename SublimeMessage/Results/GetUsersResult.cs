using SublimeMessage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeMessage.Results
{
    public class GetUsersResult:Result
    {
        public IEnumerable<User> Users { get; set; }
    }
}
