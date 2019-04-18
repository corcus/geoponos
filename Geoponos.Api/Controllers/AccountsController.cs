using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geoponos.Api.Presenters;
using Geoponos.Core.Dto.UseCaseRequests.Accounts;
using Geoponos.Core.Interfaces.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geoponos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IRegisterUserUseCase registerUseCase;
        private readonly RegisterUserPresenter registerPresenter;
        public AccountsController(IRegisterUserUseCase registerUseCase, RegisterUserPresenter registerPresenter)
        {
            this.registerPresenter = registerPresenter;
            this.registerUseCase = registerUseCase;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<ActionResult> RegisterUser([FromBody] Dto.Accounts.RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await registerUseCase.Handle(new RegisterUserRequest(request.FirstName, request.LastName, request.Email, request.UserName,request.Password), registerPresenter);
            return registerPresenter.Result;
        }
     
    }
}