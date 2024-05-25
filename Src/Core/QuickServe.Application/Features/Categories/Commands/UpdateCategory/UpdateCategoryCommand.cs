using MediatR;
using QuickServe.Application.Wrappers;

namespace QuickServe.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<BaseResult>
{
    public long Id { get; set;  }
    public string Name { get; set; }
}