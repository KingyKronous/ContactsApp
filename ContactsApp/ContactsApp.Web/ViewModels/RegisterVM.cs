using System.ComponentModel.DataAnnotations;

namespace ContactsApp.Web.ViewModels
{
    public class RegisterVM : BaseVM
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string RepeatPassword { get; set; }
    }
}
