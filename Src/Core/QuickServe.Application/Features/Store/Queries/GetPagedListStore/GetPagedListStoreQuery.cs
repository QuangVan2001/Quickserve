using MediatR;
using QuickServe.Application.Parameters;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Stores.Dtos;

namespace QuickServe.Application.Features.Store.Queries.GetPagedListStore;

public class GetPagedListStoreQuery : PagenationRequestParameter, IRequest<PagedResponse<StoreDto>>
{
    public string Name { get; set; }
}