using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeMessage.Carriers.Exceptions
{
    public class CarrierException : Exception
    {
        public CarrierException(string message): base(message) { }
    }
}
