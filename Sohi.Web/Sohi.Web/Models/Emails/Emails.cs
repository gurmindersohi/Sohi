using System;
using System.Net;
using System.Net.Mail;

namespace Sohi.Web.Models.Emails
{
    public class Emails
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Cc { get; set; }

        public string Bcc { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
        
        public string SenderEmail { get; set; }

        public string SenderPassword { get; set; }
    }
}
