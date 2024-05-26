using MediatR;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.ProductTemplates.Dtos;

namespace QuickServe.Application.Features.ProductTemplates.Queries.GetProductTemplateById;

public class GetProductTemplateByIdQuery : IRequest<BaseResult<ProductTemplateDto>>
{
      public long Id { get; set; }    
}