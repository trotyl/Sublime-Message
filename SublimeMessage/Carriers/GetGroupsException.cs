using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeMessage.Carriers
{
    public class GetGroupsException:Exception
    {
        public GetGroupsException(string message) : base(message) { }
    }
}
