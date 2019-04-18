using Geoponos.Core.Dto.GatewayResponses.Repositories;
using Geoponos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Geoponos.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<CreateUserResponse> Create(GeoponosUser user, string password);
        Task<GeoponosUser> FindByName(string userName);
        Task<bool> CheckPassword(GeoponosUser user, string password);
    }
}
