using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sohi.Web.Models.Leads;
using Sohi.Web.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sohi.Web.Controllers
{
    public class LeadsController : Controller
    {
        private readonly ILeadsRepository _leadsRepository;

        public LeadsController(ILeadsRepository leadsRepository)
        {
            _leadsRepository = leadsRepository;
        }

        public ViewResult Index()
        {
            //throw new Exception("Error in Leads View");
            var model =  _leadsRepository.GetAllLeads("1");
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

       

    }
}
