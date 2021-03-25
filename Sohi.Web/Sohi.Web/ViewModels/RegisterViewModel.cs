using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Sohi.Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password does not match.")]
        public string ConfirmPassword { get; set; }
    }
}
