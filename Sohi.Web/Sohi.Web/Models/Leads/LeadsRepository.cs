using System;
using System.Collections.Generic;
using System.Linq;

namespace Sohi.Web.Models.Leads
{
    public class LeadsRepository : ILeadsRepository
    {
        private readonly AppDbContext context;

        public LeadsRepository(AppDbContext context)
        {
            this.context = context;
        }


        public Lead Add(Lead lead)
        {
            throw new NotImplementedException();
            //context.Leads.Add(lead);
            //context.SaveChanges();

        }

        public Lead Delete(string id, string accountid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lead> GetAllLeads(string accountid)
        {

            Guid id = new Guid(accountid);

            List<Lead> leads = new List<Lead>();

            leads = context.Leads.Where(a => a.AccountId == id).ToList();
            return leads;
        }

        public Lead GetLead(string id)
        {
            throw new NotImplementedException();
        }

        public Lead Update(Lead user)
        {
            throw new NotImplementedException();
        }
    }
}
