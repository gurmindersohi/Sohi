using System;
namespace Sohi.Web.Models.Emails
{
    public interface IEmailsRepository
    {
        void SendEmailConfirmation(string emailTo, string body);
        void SendEmail(Emails email);
    }
}
