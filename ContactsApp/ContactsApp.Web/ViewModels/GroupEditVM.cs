using System.ComponentModel.DataAnnotations;

namespace ContactsApp.Web.ViewModels
{
    public class GroupEditVM : BaseVM
    {
        [Required]
        public string Name { get; set; }
    }
}
