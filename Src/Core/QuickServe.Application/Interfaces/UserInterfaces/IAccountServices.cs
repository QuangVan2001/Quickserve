using QuickServe.Application.DTOs.Account.Requests;
using QuickServe.Application.DTOs.Account.Responses;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Accounts.Dtos;
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
    }
}
