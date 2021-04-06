using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Lead> CreateLead(Lead lead)
        {
            var result = await context.Leads.AddAsync(lead);

            await context.SaveChangesAsync();

            return result.Entity;
        }

        public Lead Delete(string id, string accountid)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<Lead> GetAllLeads(string accountid)
        //{

        //    Guid id = new Guid(accountid);

        //    List<Lead> leads = new List<Lead>();

        //    leads = context.Leads.Where(a => a.AccountId == id).ToList();
        //    return leads;
        //}

        public Lead GetLead(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Lead> GetLeadById(Guid id)
        {
            return await context.Leads.FirstOrDefaultAsync(l => l.LeadId == id);
        }

        public Lead Update(Lead user)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Lead> GetAllLeads(string accountid)
        {
            Guid id = new Guid(accountid);

            List<Lead> leads = new List<Lead>();

            leads = context.Leads.Where(a => a.AccountId == id).ToList();
            return leads;

            //return await context.Leads.Where(a => a.LeadId == id).ToListAsync();

        }
    }
}
