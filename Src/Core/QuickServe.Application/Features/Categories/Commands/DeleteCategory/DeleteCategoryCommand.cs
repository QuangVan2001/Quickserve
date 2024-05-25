using MediatR;
using QuickServe.Application.Wrappers;

namespace QuickServe.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest<BaseResult>
{
    public long Id { get; set; }
}