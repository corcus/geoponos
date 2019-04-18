using System;
using System.Collections.Generic;
using System.Text;

namespace Geoponos.Core.Entities.Emails
{
    public class EmailVerificationEmail : BaseEmail
    {
        public Uri EmailValidationLink { get; set; }

        public EmailVerificationEmail(string subject, string body, string recipient, Uri emailValidationLink , List<string> CC = null, List<string> BCC = null)
        {
            this.Subject = subject;
            this.EmailValidationLink = emailValidationLink;
            this.Body = body + emailValidationLink.ToString();
            this.RecipientsAddresses = new List<string> { recipient };
            this.CCRecipientsAddresses = CC;
            this.BCCRecipientsAddresses = BCC;
        }
    }
}
