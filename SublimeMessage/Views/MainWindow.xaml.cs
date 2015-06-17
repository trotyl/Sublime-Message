using SublimeMessage.Carriers;
using SublimeMessage.Models;
using SublimeMessage.ViewModels;
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
            DataContext = new ListsViewModel
            {
                Users = new List<User>
                {
                    new User { Name = "Alice", Id = "111111", HasMessage = false },
                    new User { Name = "Bob", Id = "222222", HasMessage = true },
                }
            };
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var tmp = (ListsViewModel)DataContext;
            tmp.Users = new List<User>
            {
                new User { Name = "Alice", Id = "111111", HasMessage = false },
                new User { Name = "Bob", Id = "222222", HasMessage = false },
                new User { Name = "Cindy", Id = "333333", HasMessage = true },
            };
            return;

            var viewModel = (ListsViewModel)DataContext;
            try
            {
                var usersResult = await Carrier.GetUsers();
                if (usersResult.HasError)
                {
                    throw new GetUsersException(usersResult.Message);
                }
                viewModel.Users = usersResult.Users;

                var groupsResult = await Carrier.GetGroups();
                if (groupsResult.HasError)
                {
                    throw new GetGroupsException(groupsResult.Message);
                }
                viewModel.Groups = groupsResult.Groups;
            }
            catch (CarrierException carrierException)
            {
                MessageBox.Show(carrierException.Message, "网络错误");
            }
            catch (GetUsersException getUsersException)
            {
                MessageBox.Show(getUsersException.Message, "获取用户列表失败");
            }
            catch (GetGroupsException getGroupsException)
            {
                MessageBox.Show(getGroupsException.Message, "获取群组列表失败");
            }

        }
    }
}
