using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeMessage.Carriers.Results
{
    public class Result
    {
        public bool HasError { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
