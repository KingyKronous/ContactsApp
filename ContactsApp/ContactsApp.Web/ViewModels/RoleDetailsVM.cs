using ContactsApp.Data.Entities;

namespace ContactsApp.Web.ViewModels
{
    public class RoleDetailsVM : BaseVM
    {
        public string Name { get; set; }

        public virtual List<UserDetailsVM> Users { get; set; }
    }
}
