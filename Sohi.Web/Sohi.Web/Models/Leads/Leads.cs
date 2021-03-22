using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sohi.Web.Models.Leads
{
    public class Leads : ModelBase
    {
        public Guid? LeadId { get; set; }

        [NotMapped]
        public string EncryptedId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhotoPath { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public string AccountId { get; set; }
        public string LeadSource { get; set; }

        public bool IsPhoneCallAllowed { get; set; }
        public bool IsEmailAllowed { get; set; }
        public bool IsMember { get; set; }
        public bool IsDeleted { get; set; }

    }
}
