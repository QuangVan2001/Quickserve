using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Stores.Dtos;

namespace QuickServe.Application.Features.Store.Queries.GetPagedListStore;

public class GetPagedListStoreQueryHandler(IStoreRepository storeRepository) : IRequestHandler<GetPagedListStoreQuery, PagedResponse<StoreDto>>
{
    public async Task<PagedResponse<StoreDto>> Handle(GetPagedListStoreQuery request,
        CancellationToken cancellationToken)
    {
        var result = await storeRepository.GetPagedListAsync(request.PageNumber, request.PageSize, request.Name);
        return new PagedResponse<StoreDto>(result, request);
    }
}