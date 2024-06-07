using FluentValidation;
using QuickServe.Application.DTOs.IngredientTypes.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.DTOs.ProductTemplates.Request
{
    public class CreateTemplateRequest
    {
        public long TemplateStepId { get; set; }
        public List<IngredientTypeTemplates> IngredientType { get; set; }
    }
    public class CreateTemplateRequestValidator : AbstractValidator<CreateTemplateRequest>
    {
        public CreateTemplateRequestValidator()
        {
            RuleFor(x => x.TemplateStepId)
                 .NotEmpty().WithMessage("Id bước mẫu là bắt buộc.")
                 .GreaterThan(0).WithMessage("Id bước mẫu phải lớn hơn 0.");

            RuleForEach(x => x.IngredientType)
                .SetValidator(new IngredientTypeTemplateStepsValidator());
            RuleFor(x => x.IngredientType)
               .Must(ingredientTypes => ingredientTypes.Select(i => i.IngredientTypeId).Distinct().Count() == ingredientTypes.Count)
               .WithMessage("Mỗi loại nguyên liệu chỉ được xuất hiện một lần.");
        }
    }
}
