﻿using System.ComponentModel.DataAnnotations;

namespace ContactsApp.Web.ViewModels
{
    public class RoleEditVM : BaseVM
    {
        [Required]
        public string Name { get; set; }
    }
}
