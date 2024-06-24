using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactsApp.Web.ViewModels
{
    public class ContactEditVM : BaseVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DisplayName("Group")]
        public int GroupId { get; set; }
        public IEnumerable<SelectListItem> GroupList { get; set; }
    }
}
