using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContactsApp.Shared.Dtos
{
    public class ContactDto : BaseModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int GroupId { get; set; }
        public GroupDto Group { get; set; }
        public int? UserId { get; set; }
        public UserDto User { get; set; }
    }
}
