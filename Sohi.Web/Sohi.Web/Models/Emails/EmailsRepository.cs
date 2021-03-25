using System;
using System.Net;
using System.Net.Mail;

namespace Sohi.Web.Models.Emails
{
    public class EmailsRepository : IEmailsRepository
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

        public void SendEmail(Emails email)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(email.From);
            mail.To.Add(email.To);

            if (email.Cc != null)
            { 
                mail.CC.Add(email.Cc);
            }

            if (email.Bcc != null)
            {
                mail.Bcc.Add(email.Bcc);
            }

            mail.Subject = email.Subject;
            mail.Body = email.Body;
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.gmail.com");

            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("gurminder290195@gmail.com", "suyhttmdxskvvebp");


            client.Send(mail);

            //try
            //{
            //}
            //catch (SmtpFailedRecipientException ex)
            //{
            //    return ex.GetBaseException;
            //    // ex.FailedRecipient and ex.GetBaseException() should give you enough info.
            //}


        }

    }
}
