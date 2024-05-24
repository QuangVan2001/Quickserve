using MediatR;
using QuickServe.Application.Wrappers;

namespace QuickServe.Application.Features.Store.Commands.DeleteStore;

public class DeleteStoreCommand : IRequest<BaseResult>
{
    public long Id { get; set; }
}