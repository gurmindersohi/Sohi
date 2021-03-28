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
		public string EmailConfirmed { get; set; }
		public string TrialExpiry { get; set; }
		public string IsAccountPaid { get; set; }
		public string IsDeleted { get; set; }
		public string OnHold { get; set; }

		public string HolddDate { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedOn { get; set; }
		public string ModifiedBy { get; set; }
		public string ModifiedOn { get; set; }
		public string IsActive { get; set; }


	}
}
