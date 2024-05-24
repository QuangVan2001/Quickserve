using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Wrappers;

namespace QuickServe.Application.Features.Store.Commands.CreateStore;

public class CreateStoreCommandHandler(IStoreRepository storeRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateStoreCommand, BaseResult<long>>
{
    public async Task<BaseResult<long>> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
    {
        var store = new Domain.Stores.Entities.Store(request.Name, request.Address);
        await storeRepository.AddAsync(store);
        await unitOfWork.SaveChangesAsync();
        return new BaseResult<long>(store.Id);
    }
}