using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Data.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            this.Contacts = new List<Contact>();
            this.Groups = new List<Group>();
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual List<Contact> Contacts { get; set; }

        public virtual List<Group> Groups { get; set; }
    }
}
