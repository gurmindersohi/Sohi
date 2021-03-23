using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
//using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using MimeKit;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sohi.Web.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[AllowAnonymous]
        //public IActionResult SendEmail(string emailTo, string body)
        //{
        //    var message = new MimeMessage();

        //    message.From.Add(new MailboxAddress("Dc", "gurminder290195@gmail.com"));
        //    message.To.Add(new MailboxAddress("", emailTo));
        //    message.Subject = "Email Sent from .Net Project";
        //    message.Body = new TextPart("plain")
        //    {
        //        Text = body
        //    };

        //    using (var client = new SmtpClient())
        //    {
        //        client.Connect("smtp.gmail.com", 587, false);
        //        client.Authenticate("gurminder290195@gmail.com", "suyhttmdxskvvebp");
        //        client.Send(message);

        //        client.Disconnect(true);
        //    }

        //        return View();
        //}

        [AllowAnonymous]
        public IActionResult InSendEmail(string emailTo, string body)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("gurminder290195@gmail.com");
            mail.To.Add("gurminder29011995@gmail.com");
            mail.Subject = "Confirm your email";
            mail.Body = "Test In built email";
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.gmail.com");

            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("gurminder290195@gmail.com", "suyhttmdxskvvebp");

            client.Send(mail);

            return View();
        }
    }
}
