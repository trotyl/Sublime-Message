using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeMessage.Models
{
    public class User : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Id { get; set; }

        private bool m_hasMessage;
        public bool HasMessage
        {
            get
            {
                return m_hasMessage;
            }
            set
            {
                OnPropertyChanged(nameof(HasMessage));
                m_hasMessage = value;
            }
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
