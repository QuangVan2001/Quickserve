using MediatR;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.TemplateSteps.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.TemplateSteps.Queries.GetPagedListTemplateStepByActiveStatus
{
    public class GetPagedListTemplateStepByActiveStatusQueryHandler(ITemplateStepRepository templateStepRepository) : IRequestHandler<GetPagedListTemplateStepByActiveStatusQuery, PagedResponse<TemplateStepDTO>>
    {
        public async Task<PagedResponse<TemplateStepDTO>> Handle(GetPagedListTemplateStepByActiveStatusQuery request, CancellationToken cancellationToken)
        {
            var result = await templateStepRepository.GetPagedListByAcitveStatusAsync(request.ProductTemplateId ,request.PageNumber, request.PageSize, request.Name);
            return new PagedResponse<TemplateStepDTO>(result, request);
        }
    }
}
