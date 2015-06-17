using SublimeMessage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeMessage.Carriers.Results
{
    public class GetGroupsResult : Result
    {
        public List<Group> Groups { get; set; }
    }
}
