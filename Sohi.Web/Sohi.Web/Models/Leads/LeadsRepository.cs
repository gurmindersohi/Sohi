using System;
using System.Collections.Generic;

namespace Sohi.Web.Models.Leads
{
    public class LeadsRepository 
    {
        private readonly AppDbContext context;

        public LeadsRepository(AppDbContext context)
        {
            this.context = context;
        }


        public Leads Add(Leads user)
        {
            throw new NotImplementedException();
        }

        public Leads Delete(string id, string accountid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Leads> GetAllLeads(string accountid)
        {
            throw new NotImplementedException();
        }

        public Leads GetLead(string id, string accountid)
        {
            throw new NotImplementedException();
        }

        public Leads Update(Leads user)
        {
            throw new NotImplementedException();
        }
    }
}
