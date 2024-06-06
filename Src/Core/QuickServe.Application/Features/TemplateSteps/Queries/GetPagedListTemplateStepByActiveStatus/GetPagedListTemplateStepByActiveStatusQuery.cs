using MediatR;
using QuickServe.Application.Parameters;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.TemplateSteps.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.TemplateSteps.Queries.GetPagedListTemplateStepByActiveStatus
{
    public class GetPagedListTemplateStepByActiveStatusQuery : PagenationRequestParameter, IRequest<PagedResponse<TemplateStepDTO>>
    {
        public long ProductTemplateId { get; set; }
        public string Name { get; set; }
    }
}