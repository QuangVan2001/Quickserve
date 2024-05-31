using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.DTOs.ProductTemplates.Request
{
    public class GetAllTemplateRequest
    {
        public long ProductTemplateId { get; set; }

    }
    public class GetAllTemplateRequestValidator : AbstractValidator<GetAllTemplateRequest>
    {
        public GetAllTemplateRequestValidator()
        {
            RuleFor(x => x.ProductTemplateId)
                .NotEmpty().WithMessage("ProductTemplateId is required.")
                .GreaterThan(0).WithMessage("ProductTemplateId must be greater than 0.");
        }
    }
}
