using AutoMapper;
using Geoponos.Core.Entities;
using Geoponos.Infrastructure.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geoponos.Infrastructure.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<GeoponosUser, EFUser>().ConstructUsing(gu => new EFUser {Id = gu.Id, UserName = gu.Username, Email = gu.Email, FirstName = gu.FirstName, LastName = gu.LastName  });
            CreateMap<EFUser, GeoponosUser>().ConstructUsing(efu => new GeoponosUser { Id = efu.Id, Username = efu.UserName, Email = efu.Email, FirstName =efu.FirstName, LastName = efu.LastName });
        }
    }
}
