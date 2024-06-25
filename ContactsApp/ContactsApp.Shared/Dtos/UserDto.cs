using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Shared.Dtos
{
    public class UserDto : BaseModel
    {
        public UserDto()
        {
            this.Contacts = new List<ContactsDto>();
            this.Groups = new List<ContactsDto>();
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? RoleId { get; set; }

        public RoleDto Role { get; set; }

        public List<ContactsDto> Contacts { get; set; }

        public List<ContactsDto> Groups { get; set; }
    }
}
