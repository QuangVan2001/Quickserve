using MediatR;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.TemplateSteps.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.TemplateSteps.Queries.GetTemplateStepById
{
    public class GetTemplateStepByIdQuery : IRequest<BaseResult<TemplateStepDTO>>
    {
        public long Id { get; set; }
    }
}