using System;
using System.Collections.Generic;

namespace Sohi.Web.Models.Leads
{
    public interface ILeadsRepository
    {
        Leads GetLead(string id);
        IEnumerable<Leads> GetAllLeads(string accountid);
        Leads Add(Leads user);
        Leads Update(Leads user);
        Leads Delete(string id, string accountid);
    }
}
