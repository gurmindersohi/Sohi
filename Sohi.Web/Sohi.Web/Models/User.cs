using System;
using System.ComponentModel.DataAnnotations;

namespace Sohi.Web.Models
{
        public class User : ModelBase
        {
            public Guid? UserId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            public DateTime DateOfBirth { get; set; }
            public string Gender { get; set; }
            public string PhotoPath { get; set; }

            [Display(Name = "Remember me")]
            public bool RememberMe { get; set; }


            public bool EmailConfirmed { get; set; }

            public Guid? AccountId { get; set; }
            public string AccountName { get; set; }
            public string AccountSource { get; set; }

            public string AccessLevel { get; set; }
            public string IsDeleted { get; set; }
        }
}
