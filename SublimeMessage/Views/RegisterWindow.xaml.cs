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
using System.Windows.Shapes;

namespace SublimeMessage.Views
{
    /// <summary>
    /// RegisterWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void TextBox_CheckPlaceHolder(object sender, RoutedEventArgs e)
        {
            var box = (TextBox)sender;
            if (box.Text == "")
            {
                box.Text = (string)box.Tag;
            }
            else if (box.Text == (string)box.Tag)
            {
                box.Text = "";
            }
        }

        private async void registerButton_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Text != confirmBox.Text)
            {
                MessageBox.Show("密码不一致！");
                return;
            }

            string name, mail, password;
            if (string.IsNullOrWhiteSpace(nameBox.Text) || nameBox.Text == (string)nameBox.Tag)
            {
                name = "User" + new Random().Next();
            }
            else
            {
                name = nameBox.Text;
            }

            mail = mailBox.Text ?? "";
            password = passwordBox.Text;
            var res = await ((App)App.Current).Carrier.SendRegisterRequest(name, mail, password);
        }

    }
}
