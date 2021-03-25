using System;
namespace Sohi.Web.ViewModels
{
    public class SendEmailViewModel
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Cc { get; set; }

        public string Bcc { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
