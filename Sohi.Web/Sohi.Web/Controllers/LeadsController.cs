using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sohi.Web.Models;
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
        private readonly UserManager<User> userManager;

        public LeadsController(ILeadsRepository leadsRepository, IDataProtectionProvider dataProtectionProvider, DataProtectionPurposeStrings dataProtectionPurposeStrings,
                               UserManager<User> userManager)
        {
            _leadsRepository = leadsRepository;
            this.protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.LeadIdRouteValue);
            this.userManager = userManager;
        }

        public async Task<ViewResult> IndexAsync()
        {
            //throw new Exception("Error in Leads View");

            var user = await userManager.GetUserAsync(User);

            if (user != null)
            {
                var model = _leadsRepository.GetAllLeads(user.AccountId);

                return View(model);

            }
            //else if (user == null) {

            //    return View("NotFound");
            //}

                return View("NotFound");

            //var model = _leadsRepository.GetAllLeads("1").Select(e =>{e.EncryptedId = protector.Protect(e.Id.ToString()); return e;});
        }

        public ViewResult Details(string? id)
        {
            Lead lead = _leadsRepository.GetLead(id);
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
