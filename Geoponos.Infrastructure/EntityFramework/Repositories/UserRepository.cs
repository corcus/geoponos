using AutoMapper;
using Geoponos.Core.Dto.GatewayResponses.Repositories;
using Geoponos.Core.Entities;
using Geoponos.Core.Interfaces.Repositories;
using Geoponos.Infrastructure.EntityFramework.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Geoponos.Infrastructure.EntityFramework.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly IMapper mapper;
        private readonly UserManager<EFUser> usermanager;

        public UserRepository(IMapper mapper, UserManager<EFUser> usermanager)
        {
            this.mapper = mapper;
            this.usermanager = usermanager;
        }     

        public async Task<CreateUserResponse> Create(GeoponosUser user,string password)
        {
            EFUser efUser = mapper.Map<EFUser>(user);
            var result = await usermanager.CreateAsync(efUser, password);
            if (result.Succeeded)
            {
                var token = await usermanager.GenerateEmailConfirmationTokenAsync(efUser);
                Uri emailVerificationLink;
                Uri.TryCreate($"https://geoponos.gr/Accounts/verifyEmail?token={token}",UriKind.Absolute, out emailVerificationLink);
                return new CreateUserResponse(emailVerificationLink, true);
            }
            else
            {
                return new CreateUserResponse(null, false, result.Errors.Select(e => new Core.Dto.Error(e.Code, e.Description)));
            }            
        }

        public async Task<GeoponosUser> FindByName(string userName)
        {
            return mapper.Map<GeoponosUser>(await usermanager.FindByNameAsync(userName));
        }

        public async Task<bool> CheckPassword(GeoponosUser user, string password)
        {
            return await usermanager.CheckPasswordAsync(mapper.Map<EFUser>(user), password);
        }
    }
}
