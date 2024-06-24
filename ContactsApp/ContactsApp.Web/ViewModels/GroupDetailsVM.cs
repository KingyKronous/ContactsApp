namespace ContactsApp.Web.ViewModels
{
    public class GroupDetailsVM : BaseVM
    {
        public string Name { get; set; }
        public int? UserId { get; set; }
        public UserDetailsVM User { get; set; }
        public List<ContactDetailsVM> Contacts { get; set; }
    }
}
