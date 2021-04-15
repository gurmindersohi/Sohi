using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Sohi.Web.ViewModels.Social.Facebook
{
    public class PostCreateViewModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }
}
