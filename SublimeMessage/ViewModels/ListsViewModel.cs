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
        private List<User> m_users;
        public List<User> Users
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

        private List<Group> m_groups;
        public List<Group> Groups
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

        public void AddUser(User user)
        {
            Users.Add(user);
            OnPropertyChanged(nameof(Users));
        }

        public void AddGroup(Group group)
        {
            Groups.Add(group);
            OnPropertyChanged(nameof(Groups));
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
