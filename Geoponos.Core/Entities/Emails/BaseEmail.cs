using System;
using System.Collections.Generic;
using System.Text;

namespace Geoponos.Core.Entities.Emails
{
    public abstract class BaseEmail
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> RecipientsAddresses { get; set; }
        public List<string> CCRecipientsAddresses { get; set; }
        public List<string> BCCRecipientsAddresses { get; set; }       
    }
}
