using System;
using System.Collections.Generic;
using System.Linq;

namespace Sohi.Web.Models.Leads
{
    public class MockLeadsRepository : ILeadsRepository
    {
        private List<Leads> _leadslist;

        public MockLeadsRepository()
        {
            _leadslist = new List<Leads>()
            { 
                new Leads(){ LeadId = new Guid("c38a4e17-8e14-4dca-b654-578a9743d050"), FullName = "Gurminder", Email = "gurminder290195@gmail.com", IsActive = true, AccountId = "1"},
                new Leads(){ LeadId = new Guid("c38a4e17-8e14-4dca-b654-578a9743d051"), FullName = "Simran", Email = "simran@gmail.com", IsActive = true, AccountId = "1"},
                new Leads(){ LeadId = new Guid("c38a4e17-8e14-4dca-b654-578a9743d052"), FullName = "Shivani", Email = "Shivani@gmail.com", IsActive = true, AccountId = "1"},
                new Leads(){ LeadId = new Guid("c38a4e17-8e14-4dca-b654-578a9743d053"), FullName = "Gagan", Email = "gagan@gmail.com", IsActive = true, AccountId = "1"},
                new Leads(){ LeadId = new Guid("c38a4e17-8e14-4dca-b654-578a9743d054"), FullName = "Raminder", Email = "raminder@gmail.com", IsActive = true, AccountId = "1"},
                new Leads(){ LeadId = new Guid("c38a4e17-8e14-4dca-b654-578a9743d055"), FullName = "Harjinder", Email = "harjinder@gmail.com", IsActive = true, AccountId = "1"}
            };

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
            return _leadslist;
        }

        public Leads GetLead(string id)
        {
            return _leadslist.FirstOrDefault(l => l.LeadId == new Guid(id));
        }

        public Leads Update(Leads user)
        {
            throw new NotImplementedException();
        }
    }
}
