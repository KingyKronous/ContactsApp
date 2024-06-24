using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Data.Entities
{
    public class Contact : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
