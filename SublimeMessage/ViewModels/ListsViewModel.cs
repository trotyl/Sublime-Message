using SublimeMessage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeMessage.ViewModels
{
    public class ListsViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Group> Groups { get; set; }
    }
}
