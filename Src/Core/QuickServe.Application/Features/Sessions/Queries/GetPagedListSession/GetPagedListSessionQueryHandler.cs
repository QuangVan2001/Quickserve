using MediatR;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.ProductTemplates.Dtos;
using System.Threading.Tasks;
using System.Threading;
using QuickServe.Domain.Sessions.Dtos;

namespace QuickServe.Application.Features.Sessions.Queries.GetPagedListSession;

public class GetPagedListSessionQueryHandler(ISessionRepository sessionRepository) : IRequestHandler<GetPagedListSessionQuery, PagedResponse<SessionDto>>
{
    public async Task<PagedResponse<SessionDto>> Handle(GetPagedListSessionQuery request, CancellationToken cancellationToken)
    {
        var result = await sessionRepository.GetPagedListAsyncByStore(request.StoreId, request.PageNumber, request.PageSize, request.Name);

        return new PagedResponse<SessionDto>(result, request);
    }
}