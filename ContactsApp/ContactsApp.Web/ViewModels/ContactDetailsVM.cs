using System.ComponentModel;

namespace ContactsApp.Web.ViewModels
{
    public class ContactDetailsVM : BaseVM
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [DisplayName("Group")]
        public int GroupId { get; set; }
        public GroupDetailsVM Group { get; set; }
        public int? UserId { get; set; }
        public UserDetailsVM User { get; set; }
    }
}
