using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContactsApp.Shared.Dtos
{
    public class ContactsDto : BaseModel
    {
        public ContactsDto()
        {
            this.Contacts = new List<ContactsDto>();
        }

        public string Name { get; set; }
        public int? UserId { get; set; }
        public UserDto User { get; set; }
        public List<ContactsDto> Contacts { get; set; }
    }
}
