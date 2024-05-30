using FluentValidation;
using QuickServe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.TemplateSteps.Queries.GetTemplateStepById
{
    public class GetTemplateStepByIdQueryValidator : AbstractValidator<GetTemplateStepByIdQuery>
    {
        public GetTemplateStepByIdQueryValidator(ITranslator translator)
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(translator["Id is required."])
                .GreaterThan(0).WithMessage(translator["Id must be greater than 0."]);
        }
    }
}
