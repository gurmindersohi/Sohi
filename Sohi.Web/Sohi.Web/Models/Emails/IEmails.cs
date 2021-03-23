using System;
namespace Sohi.Web.Models.Emails
{
    public interface IEmails
    {
        void SendEmailConfirmation(string emailTo, string body);
    }
    
}
