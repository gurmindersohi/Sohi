using System;
using System.Net;
using System.Net.Mail;

namespace Sohi.Web.Models.Emails
{
    public class Emails : IEmails
    {
        public void SendEmailConfirmation(string emailTo, string body)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("gurminder290195@gmail.com");
            mail.To.Add(emailTo);
            mail.Subject = "Confirm your email";
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.gmail.com");

            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("gurminder290195@gmail.com", "suyhttmdxskvvebp");

            client.Send(mail);

        }
    }
}
