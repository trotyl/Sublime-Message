using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeMessage.Carriers.Messages
{
    public class BaseMessage
    {
        public DateTime Time { get; set; }
        public string Type { get; set; }
        public int Index { get; set; }
    }
}
