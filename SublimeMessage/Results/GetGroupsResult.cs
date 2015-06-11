using SublimeMessage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeMessage.Results
{
    public class GetGroupsResult : Result
    {
        public IEnumerable<Group> Groups { get; set; }
    }
}
