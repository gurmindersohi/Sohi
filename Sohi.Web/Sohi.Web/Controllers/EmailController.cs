using System;
using System.Collections.Generic;
using System.Linq;
//using System.Net.Mail;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sohi.Web.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult SendEmail(string url)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("", "gurminder290195@gmail.com"));
            message.To.Add(new MailboxAddress("", "gurminder29011995@gmail.com"));
            message.Subject = "I am Email Subject!";
            message.Body = new TextPart("plain")
            {
                Text = "I am Email Body!" + url
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("gurminder290195@gmail.com", "suyhttmdxskvvebp");
                client.Send(message);

                client.Disconnect(true);
            }

                return View();
        }
    }
}
