﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeMessage.Carriers.Exceptions
{
    public class AddFriendException:Exception
    {
        public AddFriendException(string message): base(message) { }
    }
}
