using MediatR;
using QuickServe.Application.Interfaces.UserInterfaces;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Accounts.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.Accounts.Queries.GetPagedListAccount;

public class GetPagedListAccountQueryHandler(IAccountServices accountServices) : IRequestHandler<GetPagedListAccountQuery, PagedResponse<AccountDto>>
{
    public async Task<PagedResponse<AccountDto>> Handle(GetPagedListAccountQuery request, CancellationToken cancellationToken)
    {
        var result = await accountServices.GetPagedListAsync(request.PageNumber, request.PageSize, request.Name, request.Roles);
        return new PagedResponse<AccountDto>(result, request);
    }
}