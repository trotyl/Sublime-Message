using SublimeMessage.Carriers;
using SublimeMessage.Helpers;
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

        private async void submitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var username = usernameBox.Text;
                var email = emailBox.Text;
                var password = passwordBox.Text;
                var confirmPassword = confirmBox.Text;

                Validator.ValidateUsername(username);
                Validator.ValidateEmail(email);
                Validator.ValidatePassword(password);
                Validator.ValidateEquality(password, confirmPassword);

                var result = await Carrier.SendRegisterRequest(username, email, password);
                if(result.HasError)
                {
                    throw new RegesterFailedException(result.Message);
                }

                MessageBox.Show($"您的SM号为：{result.Id}，请妥善保管。", "注册成功");
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
            catch (RegesterFailedException regesterFailedException)
            {
                MessageBox.Show(regesterFailedException.Message, "注册失败");
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
