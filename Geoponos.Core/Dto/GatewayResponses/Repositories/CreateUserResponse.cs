using System;
using System.Collections.Generic;
using System.Text;

namespace Geoponos.Core.Dto.GatewayResponses.Repositories
{
    public class CreateUserResponse : BaseGatewayResponse
    {
        public Uri EmailVerificationUri { get; set; }

        public CreateUserResponse(Uri emailVerificationUri,  bool success = false, IEnumerable<Error> errors = null) : base (success, errors)
        {
            this.EmailVerificationUri = emailVerificationUri;
        }
    }
}
