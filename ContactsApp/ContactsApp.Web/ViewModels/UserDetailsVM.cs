using ContactsApp.Data.Entities;

namespace ContactsApp.Web.ViewModels
{
    public class UserDetailsVM : BaseVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? RoleId { get; set; }
        public virtual RoleDetailsVM Role { get; set; }
        public virtual List<ContactDetailsVM> Contacts { get; set; }
        public virtual List<GroupDetailsVM> Groups { get; set; }
    }
}
