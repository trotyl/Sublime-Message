using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SublimeMessage.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsPtopMode { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(bool isPtop) : this()
        {
            IsPtopMode = isPtop;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var res = await ((App)App.Current).Carrier.SendUserListRequest();
            if (!res.Item1)
            {
                MessageBox.Show("获取在线列表失败！错误码" + res.Item2);
                return;
            }

            foreach (var user in res.Item3)
            {
                var block = new TextBlock();
                block.Text = user;
                onlineList.Items.Add(block);
            }
        }
    }
}
