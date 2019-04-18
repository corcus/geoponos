using Geoponos.Core.Dto.UseCaseRequests.Accounts;
using Geoponos.Core.Dto.UseCaseResponses.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geoponos.Core.Interfaces.UseCases
{
    public interface IRegisterUserUseCase : IUseCaseRequestHandler<RegisterUserRequest,RegisterUserResponse>
    {
    }
}
