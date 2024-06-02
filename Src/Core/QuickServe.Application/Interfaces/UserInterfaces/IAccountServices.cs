using QuickServe.Application.DTOs;
using QuickServe.Application.DTOs.Account.Requests;
using QuickServe.Application.DTOs.Account.Responses;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Accounts.Dtos;
using System;
using System.Threading.Tasks;

namespace QuickServe.Application.Interfaces.UserInterfaces
{
    public interface IAccountServices
    {
        Task<BaseResult<string>> RegisterGostAccount();
        Task<BaseResult> ChangePassword(ChangePasswordRequest model);
        Task<BaseResult> ChangeUserName(ChangeUserNameRequest model);
        Task<BaseResult<AuthenticationResponse>> Authenticate(AuthenticationRequest login);
        Task<BaseResult<AuthenticationResponse>> AuthenticateByUserName(string username);
        Task<BaseResult<TokenDto>> RefreshToken(TokenDto token);
        Task<BaseResult> CreateAccount(CreateAccountRequest request);
        Task<PagenationResponseDto<AccountDto>> GetPagedListAsync(int pageNumber, int pageSize, string name, string[] roles);
        Task<BaseResult<AccountDto>> GetAccountById(Guid id);
        Task<BaseResult<AccountDto>> FindByEmailAsync(string email);
    }
}
