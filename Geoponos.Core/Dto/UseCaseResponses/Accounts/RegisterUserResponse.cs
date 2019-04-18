using System;
using System.Collections.Generic;
using System.Text;

namespace Geoponos.Core.Dto.UseCaseResponses.Accounts
{
    public class RegisterUserResponse : BaseUseCaseResponse
    {
        public IEnumerable<string> Errors { get; }

        public RegisterUserResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RegisterUserResponse(bool success = false, string message = null) : base(success, message)
        {

        }
    }
}
