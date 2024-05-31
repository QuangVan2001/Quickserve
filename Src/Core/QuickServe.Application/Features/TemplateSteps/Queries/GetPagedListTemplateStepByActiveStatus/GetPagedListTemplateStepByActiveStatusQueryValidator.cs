using FluentValidation;
using QuickServe.Application.Features.Categories.Queries.GetPagedListCategoryByActiveStatus;
using QuickServe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.TemplateSteps.Queries.GetPagedListTemplateStepByActiveStatus
{
    public class GetPagedListTemplateStepByActiveStatusQueryValidator : AbstractValidator<GetPagedListTemplateStepByActiveStatusQuery>
    {
        public GetPagedListTemplateStepByActiveStatusQueryValidator(ITranslator translator)
        {
            RuleFor(x => x.ProductTemplateId)
                .NotEmpty().WithMessage(translator["ProductTemplateId is required."])
                .GreaterThan(0).WithMessage(translator["ProductTemplateId must be greater than 0."]);

            RuleFor(x => x.Name)
                .MaximumLength(100).WithMessage(translator["Name must not exceed 100 characters."]);
        }
    }
}
