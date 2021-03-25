using System;
using System.ComponentModel.DataAnnotations;

namespace Sohi.Web.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
