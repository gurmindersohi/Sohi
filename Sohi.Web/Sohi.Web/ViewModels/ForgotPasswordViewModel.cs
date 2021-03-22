﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Sohi.Web.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
