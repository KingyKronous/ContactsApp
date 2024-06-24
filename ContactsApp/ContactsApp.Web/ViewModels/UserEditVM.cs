using System.ComponentModel.DataAnnotations;

namespace ContactsApp.Web.ViewModels
{
    public class UserEditVM : BaseVM
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
