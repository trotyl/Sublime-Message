using SublimeMessage.Carriers;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = await Carrier.GetUsers();
                if(result.HasError)
                {
                    throw new GetUsersException(result.Message);
                }

                DataContext = result.Users;
            }
            catch (CarrierException carrierException)
            {
                MessageBox.Show(carrierException.Message, "网络错误");
            }
            catch (GetUsersException getUsersException)
            {
                MessageBox.Show(getUsersException.Message, "获取用户列表失败");
            }

        }
    }
}
