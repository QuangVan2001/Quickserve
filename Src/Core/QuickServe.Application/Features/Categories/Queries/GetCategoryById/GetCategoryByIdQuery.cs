using MediatR;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Categories.Dtos;

namespace QuickServe.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<BaseResult<CategoryDto>>
{
    public long Id { get; set; }
}