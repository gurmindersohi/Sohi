using System;
namespace Sohi.Web.Models.Account
{
    public class AccountRepository : IAccountRepository
    {

        private readonly AppDbContext context;

        public AccountRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Account Add(Account account)
        {
            context.Accounts.Add(account);
            context.SaveChanges();

            return account;
        }
    }
}
