﻿using SublimeMessage.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SublimeMessage
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public Carrier Carrier { get; set; }

        public App()
        {
            Carrier = new Carrier();
        }
    }
}
