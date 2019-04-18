using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Geoponos.Core.Interfaces.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmail<TEmail>(TEmail email) where TEmail : class;
    }
}
