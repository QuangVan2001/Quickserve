using MediatR;
using QuickServe.Application.Wrappers;

namespace QuickServe.Application.Features.Store.Commands.UpdateStore;

public class UpdateStoreCommand: IRequest<BaseResult>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}