using Geoponos.Core.Dto.UseCaseRequests.Accounts;
using Geoponos.Core.Dto.UseCaseResponses.Accounts;
using Geoponos.Core.Entities.Emails;
using Geoponos.Core.Interfaces;
using Geoponos.Core.Interfaces.Repositories;
using Geoponos.Core.Interfaces.Services;
using Geoponos.Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geoponos.Core.UseCases
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository repository;
        private readonly IEmailService emailService;

        public RegisterUserUseCase(IUserRepository repository, IEmailService emailService)
        {
            this.repository = repository;
            this.emailService = emailService;
        }

        public  async Task<bool> Handle(RegisterUserRequest message, IOutputPort<RegisterUserResponse> outputPort)
        {
            var createResult = await repository.Create(new Entities.GeoponosUser(message.UserName,message.FirstName,message.LastName,message.Email), message.Password);
            if (createResult.Success)
            {
                EmailVerificationEmail verificationEmail = new EmailVerificationEmail("Welcome", "Click the link to validate your email", message.Email, createResult.EmailVerificationUri);
                await emailService.SendEmail(verificationEmail);
                outputPort.Handle(new RegisterUserResponse(true));
            }
            else
            {
                outputPort.Handle(new RegisterUserResponse(createResult.Errors.Select(e => e.Description)));
            }
            return createResult.Success;
        }
    }
}
