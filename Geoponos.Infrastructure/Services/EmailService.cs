using Geoponos.Core.Interfaces.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Geoponos.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SendEmail<TEmail>(TEmail email) where TEmail : class
        {
            bool success = false;
            string emailString = JsonConvert.SerializeObject(email);
            try
            {
                System.IO.File.WriteAllText("confirmationLink.json", emailString);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }
    }
}
