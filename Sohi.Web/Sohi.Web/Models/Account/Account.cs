using System;
namespace Sohi.Web.Models.Account
{
    public class Account
    {
        
        public Guid AccountId { get; set; }

		public string AccountName { get; set; }
		public string AccountType { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Province { get; set; }
		public string Country { get; set; }
		public string PostalCode { get; set; }
		public string UsersLimit { get; set; }

		public string Logo { get; set; }
		public bool EmailConfirmed { get; set; }
		public DateTime TrialExpiry { get; set; }
		public bool IsAccountPaid { get; set; }
		public bool IsDeleted { get; set; }
		public bool OnHold { get; set; }

		public DateTime HolddDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public string ModifiedBy { get; set; }
		public DateTime ModifiedOn { get; set; }
		public bool IsActive { get; set; }


	}
}
