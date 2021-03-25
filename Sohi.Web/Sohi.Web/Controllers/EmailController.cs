using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
//using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sohi.Web.Models.Emails;
using Sohi.Web.ViewModels;
//using MimeKit;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sohi.Web.Controllers
{
    public class EmailController : Controller
    {

        private readonly IEmailsRepository _emailsRepository;

        public EmailController(IEmailsRepository emailsRepository)
        {
            _emailsRepository = emailsRepository;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Send()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Send(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var email = new Emails
                {
                    From = "gurminder290195@gmail.com",
                    To = model.To,
                    Cc = model.Cc,
                    Bcc = model.Bcc,
                    Subject = model.Subject,
                    Body = model.Body,
                };


                _emailsRepository.SendEmail(email);

            }

            return View(model);
        }

    }
}
