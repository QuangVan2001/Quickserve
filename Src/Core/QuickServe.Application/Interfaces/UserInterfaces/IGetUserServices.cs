using QuickServe.Application.DTOs.Account.Requests;
using QuickServe.Application.DTOs.Account.Responses;
using QuickServe.Application.Wrappers;
using System.Threading.Tasks;

namespace QuickServe.Application.Interfaces.UserInterfaces
{
    public interface IGetUserServices
    {
        Task<PagedResponse<UserDto>> GetPagedUsers(GetAllUsersRequest model);
    }
}
