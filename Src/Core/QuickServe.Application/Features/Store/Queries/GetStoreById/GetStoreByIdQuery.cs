using MediatR;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Stores.Dtos;

namespace QuickServe.Application.Features.Store.Queries.GetStoreById;

public class GetStoreByIdQuery : IRequest<BaseResult<StoreDto>>
{
    public long Id { get; set; }
}