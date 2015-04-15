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
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            for (int i = 1; i < 1048576; i++)
            {
                for (int j = 1; j < 1024; j++)
                {
                    var t1 = i + j;
                    var t2 = i - j;
                    var t3 = i * j;
                    var t4 = i / j;
                    var t5 = i % j;
                }
            }
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

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            var signUpWindow = new RegisterWindow();
            signUpWindow.ShowDialog();
        }

        private async void signInButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idBox.Text) || idBox.Text == (string)idBox.Tag)
            {
                MessageBox.Show("用户名或邮箱无效！");
                return;
            }
            var res = await ((App)App.Current).Carrier.SendLoginRequest(idBox.Text, passwordBox.Text);
            if (res.Item1)
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("登录失败，错误码" + res.Item2);
                return;
            }
        }

        private void ptopButton_Click(object sender, RoutedEventArgs e)
        {
            string name;
            if (string.IsNullOrWhiteSpace(idBox.Text) || idBox.Text == (string)idBox.Tag)
            {
                name = "User" + new Random().Next();
            }
            else
            {
                name = idBox.Text;
            }
            var mainWindow = new MainWindow(true);
        }
    }
}
