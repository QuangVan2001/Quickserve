using MediatR;
using QuickServe.Application.Parameters;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Accounts.Dtos;

namespace QuickServe.Application.Features.Accounts.Queries.GetPagedListAccount;

public class GetPagedListAccountQuery : PagenationRequestParameter, IRequest<PagedResponse<AccountDto>>
{
    public string Name { get; set; }
    public string[] Roles { get; set; } = [];
}