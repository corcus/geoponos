using Geoponos.Core.Dto.UseCaseResponses.Accounts;
using Geoponos.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Geoponos.Api.Presenters
{
    public class RegisterUserPresenter : IOutputPort<RegisterUserResponse>
    {
        public JsonResult Result { get; }
        public RegisterUserPresenter()
        {
            Result = new JsonResult(null);
        }

        public void Handle(RegisterUserResponse response)
        {
            Result.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            Result.Value = response;
        }
    }
}
