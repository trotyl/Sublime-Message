using SublimeMessage.Carriers;
using SublimeMessage.Enums;
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
using System.Windows.Shapes;

namespace SublimeMessage.Views
{
    /// <summary>
    /// ChatWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ChatWindow : Window
    {
        private EntityType m_type = EntityType.User;
        private string m_id = "000000";
        private IEnumerable<Message> m_messages;

        public ChatWindow()
        {
            InitializeComponent();
            DataContext = new MessagesViewModel();
        }

        public ChatWindow(EntityType type, string id) : this() { m_type = type; m_id = id; }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var viewModel = (MessagesViewModel)DataContext;
            Carrier.RetriveMessages(m_type, m_id, x => viewModel.Messages.Add(x));

            await Task.Delay(3000);
            Carrier.Test();
        }
    }
}
