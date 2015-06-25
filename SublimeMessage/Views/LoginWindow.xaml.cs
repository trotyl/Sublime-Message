using SublimeMessage.Helpers;
using SublimeMessage.Carriers;
using SublimeMessage.Carriers.Exceptions;
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
            Hide();
            signUpWindow.ShowDialog();
            Show();
        }

        private async void signInButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var username = usernameBox.Text;
                var password = passwordBox.Text;
                
                Validator.ValidateUsername(username);
                Validator.ValidatePassword(password);

                var result = await Carrier.Login(username, password);
                if(result.HasError)
                {
                    throw new LoginFailedException(result.Message);
                }
                
                var mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            catch (ArgumentException argumentException)
            {
                MessageBox.Show(argumentException.Message, "非法输入");
            }
            catch (CarrierException carrierException)
            {
                MessageBox.Show(carrierException.Message, "网络错误");
            }
            catch (LoginFailedException loginFailedException)
            {
                MessageBox.Show(loginFailedException.Message, "登录失败");
            }
        }

        private async void ptopButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var username = usernameBox.Text;
                var password = passwordBox.Text;

                Validator.ValidateUsername(username);

                var res = await Carrier.InitPtop(username);
                if (res.HasError)
                {
                    MessageBox.Show(res.Message, "登录失败");
                    return;
                }

                var mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            catch (ArgumentException argumentException)
            {
                MessageBox.Show(argumentException.Message, "非法输入");
            }
            catch (CarrierException carrierException)
            {
                MessageBox.Show(carrierException.Message, "网络错误");
            }
        }

    }
}
