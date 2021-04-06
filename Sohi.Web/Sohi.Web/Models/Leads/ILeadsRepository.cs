using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sohi.Web.Models.Leads
{
    public interface ILeadsRepository
    {
        Lead GetLead(string id);
        IEnumerable<Lead> GetAllLeads(string accountid);
        Lead Add(Lead lead);
        Lead Update(Lead lead);
        Lead Delete(string id, string accountid);

        //API

        //IEnumerable<Lead> GetAllLeads(string accountid);
        Task<Lead> GetLeadById(Guid id);
        Task<Lead> CreateLead(Lead lead);

    }
}
