using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickServe.Application.DTOs.Account.Requests;
using QuickServe.Application.DTOs.Account.Responses;
using QuickServe.Application.Features.Accounts.Commands;
using QuickServe.Application.Features.Accounts.Queries.GetPagedListAccount;
using QuickServe.Application.Interfaces.UserInterfaces;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Accounts.Dtos;
using System;
using System.Threading.Tasks;

namespace QuickServe.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class AccountsController(IAccountServices accountServices) : BaseApiController
    {
        [HttpPost("authenticate")]
        public async Task<BaseResult<AuthenticationResponse>> Authenticate([FromBody] AuthenticationRequest request)
            => await accountServices.Authenticate(request);

        //[HttpPut, Authorize]
        //public async Task<BaseResult> ChangeUserName(ChangeUserNameRequest model)
        //    => await accountServices.ChangeUserName(model);

        //[HttpPut, Authorize]
        //public async Task<BaseResult> ChangePassword(ChangePasswordRequest model)
        //    => await accountServices.ChangePassword(model);

        //[HttpPost]
        //public async Task<BaseResult<AuthenticationResponse>> Start()
        //{
        //    var gostUsername = await accountServices.RegisterGostAccount();
        //    return await accountServices.AuthenticateByUserName(gostUsername.Data);
        //}

        [HttpPost("refresh")]
        public async Task<BaseResult<TokenDto>> Refresh([FromBody] TokenDto token)
        {
            var tokenReturn = await accountServices.RefreshToken(token);
            return tokenReturn;
        }

        [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<BaseResult<Guid>> CreateAccount([FromBody] CreateAccountCommand request)
            => await Mediator.Send(request);

        [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("paged")]
        public async Task<BaseResult> GetPagedListAccountQuery([FromQuery] GetPagedListAccountQuery query)
            => await Mediator.Send(query);

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<BaseResult<AccountDto>> GetAccountById([FromQuery] Guid id)
            => await accountServices.GetAccountById(id);
    }
}