using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Sohi.Web.Models.Leads;
using Sohi.Web.Security;
using Sohi.Web.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sohi.Web.Controllers
{
    public class LeadsController : Controller
    {
        private readonly ILeadsRepository _leadsRepository;
        private readonly IDataProtector protector;

        public LeadsController(ILeadsRepository leadsRepository, IDataProtectionProvider dataProtectionProvider, DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            _leadsRepository = leadsRepository;
            this.protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.LeadIdRouteValue);
        }

        public ViewResult Index()
        {
            //throw new Exception("Error in Leads View");

            var model = _leadsRepository.GetAllLeads("1");

            //var model = _leadsRepository.GetAllLeads("1").Select(e =>{e.EncryptedId = protector.Protect(e.Id.ToString()); return e;});
            return View(model);
        }

        public ViewResult Details(string? id)
        {
            Leads lead = _leadsRepository.GetLead(id);
            if (lead == null) {
                Response.StatusCode = 404;
                return View("NotFound", id);
            }

            LeadsDetailsViewModel leadsDetailsViewModel = new LeadsDetailsViewModel()
            {
                leads = lead,
                PageTitle = "Lead Details"
            };
            return View(leadsDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {


            return View();
        }

        [HttpGet]
        public ViewResult GetLeads()
        {
            var model = _leadsRepository.GetAllLeads("1");

            List<string> list = new List<string>();

            foreach (var item in model)
            {
                list.Add(item.Email);

            }

            string emails = String.Join(",", list.ToArray());

            SendEmailViewModel emailsViewModel = new SendEmailViewModel()
            {
                To = emails,
            };

            return View("../Email/Send", emailsViewModel);
        }

    }
}
