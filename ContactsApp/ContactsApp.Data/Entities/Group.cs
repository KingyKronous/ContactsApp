using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Data.Entities
{
    public class Group : BaseEntity
    {
        public Group()
        {
            this.Contacts = new List<Contact>();
        }
        public string Name { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<Contact> Contacts { get; set; }
    }
}
