using MediatR;
using QuickServe.Application.Wrappers;

namespace QuickServe.Application.Features.ProductTemplates.Commands.DeleteProductTemplate;

public class DeleteProductTemplateCommand : IRequest<BaseResult>
{
    public long Id { get; set; }
}