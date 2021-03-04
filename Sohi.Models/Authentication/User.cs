using System;
using Sohi.Models.Common;

namespace Sohi.Models.Authentication
{
    public class User : ModelBase
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhotoPath { get; set; }

        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountSource { get; set; }

        public string AccessLevel { get; set; }
        public string IsAccountPaid { get; set; }
        public string IsDeleted { get; set; }
        public DateTime TrialExpiry { get; set; }
    }
}
