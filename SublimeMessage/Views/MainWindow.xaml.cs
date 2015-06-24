using SublimeMessage.AsyncStates;
using SublimeMessage.Carriers;
using SublimeMessage.Carriers.Exceptions;
using SublimeMessage.Enums;
using SublimeMessage.Models;
using SublimeMessage.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private EntityType m_searchObjective;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ListsViewModel();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var viewModel = (ListsViewModel)DataContext;
            try
            {
                var usersResult = await Carrier.GetUsers();
                if (usersResult.HasError)
                {
                    throw new GetUsersException(usersResult.Message);
                }
                Array.ForEach(usersResult.Users.ToArray(), x => viewModel.Users.Add(x));

                var groupsResult = await Carrier.GetGroups();
                if (groupsResult.HasError)
                {
                    throw new GetGroupsException(groupsResult.Message);
                }
                Array.ForEach(groupsResult.Groups.ToArray(), x => viewModel.Groups.Add(x));
                Carrier.UserOnline = new Task(x => 
                    Dispatcher.Invoke(() => 
                        viewModel.Users.Add(((AsyncUserState)x).User)), new AsyncUserState());
                Carrier.UserOffline = new Task(x =>
                    Dispatcher.Invoke(() =>
                        viewModel.Users.Remove(((AsyncUserState)x).User)), new AsyncUserState());
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

        private void addFriendButton_Click(object sender, RoutedEventArgs e)
        {
            searchGrid.Visibility = Visibility.Visible;
            m_searchObjective = EntityType.User;
        }

        private void addGroupButton_Click(object sender, RoutedEventArgs e)
        {
            searchGrid.Visibility = Visibility.Visible;
            m_searchObjective = EntityType.Group;
        }

        private void searchCancelButton_Click(object sender, RoutedEventArgs e)
        {
            searchGrid.Visibility = Visibility.Collapsed;
        }

        private async void searchSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var id = searchBox.Text;
            var viewModel = (ListsViewModel)DataContext;
            try
            {
                var addFriendResult = await Carrier.AddFriend(id);
                if (addFriendResult.HasError)
                {
                    throw new AddFriendException(addFriendResult.Message);
                }
                viewModel.Users.Add(addFriendResult.User);
            }
            catch (CarrierException carrierException)
            {
                MessageBox.Show(carrierException.Message, "网络错误");
            }
            catch (AddFriendException addFriendException)
            {
                MessageBox.Show(addFriendException.Message, "添加好友失败");
            }
        }

        private void userGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var chatWindow = new ChatWindow(EntityType.User, (sender as Grid).Tag as string);
            chatWindow.Show();
        }

        private void groupGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var chatWindow = new ChatWindow(EntityType.Group, (sender as Grid).Tag as string);
            chatWindow.Show();
        }
    }

}
