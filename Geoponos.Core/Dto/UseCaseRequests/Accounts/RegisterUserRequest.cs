using Geoponos.Core.Dto.UseCaseResponses.Accounts;
using Geoponos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geoponos.Core.Dto.UseCaseRequests.Accounts
{
    public class RegisterUserRequest : IUseCaseRequest<RegisterUserResponse>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string UserName { get; }
        public string Password { get; }

        public RegisterUserRequest(string firstName, string lastName, string email, string userName, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.UserName = userName;
            this.Password = password;
        }
    }
}
