﻿using SublimeMessage.Carriers;
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

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var username = usernameBox.Text;
                var email = emailBox.Text;
                var password = passwordBox.Text;
                var confirmPassword = confirmBox.Text;

                Validator.ValidateUsername(username);
                Validator.ValidateEmail(email);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
