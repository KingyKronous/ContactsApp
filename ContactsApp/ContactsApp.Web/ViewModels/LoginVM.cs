using System.ComponentModel.DataAnnotations;

namespace ContactsApp.Web.ViewModels
{
    public class LoginVM : BaseVM
    {
		[Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
