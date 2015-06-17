using SublimeMessage.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeMessage.ViewModels
{
    public class ListsViewModel : INotifyPropertyChanged
    {
        private IEnumerable<User> m_users;
        public IEnumerable<User> Users
        {
            get
            {
                return m_users;
            }
            set
            {
                m_users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        private IEnumerable<Group> m_groups;
        public IEnumerable<Group> Groups
        {
            get
            {
                return m_groups;
            }
            set
            {
                m_groups = value;
                OnPropertyChanged(nameof(Groups));
            }
        }

        public ListsViewModel()
        {
            Users = new List<User>();
            Groups = new List<Group>();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
