using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.DTOs.ProductTemplates.Request
{
    public class DeleteTemplateRequest
    {
        public long TemplateStepId { get; set; }
    }
    public class DeleteTemplateRequestValidator : AbstractValidator<DeleteTemplateRequest>
    {
        public DeleteTemplateRequestValidator()
        {
            RuleFor(x => x.TemplateStepId)
                .NotEmpty().WithMessage("TemplateStepId is required.")
                .GreaterThan(0).WithMessage("TemplateStepId must be greater than 0.");
        }
    }
}
