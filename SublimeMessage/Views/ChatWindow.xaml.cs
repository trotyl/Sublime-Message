using SublimeMessage.Enums;
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
        private EntityType m_type;
        private string m_id;

        public ChatWindow()
        {
            InitializeComponent();
        }

        public ChatWindow(EntityType type, string id) : this() { m_type = type; m_id = id; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
