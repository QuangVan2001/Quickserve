using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.DTOs.IngredientNutrions.Request
{
    public class CreateIngredientNutritionRequest
    {
        public long IngredientId { get; set; }
        public List<long> NutritionIds { get; set; }
    }

    public class CreateIngredientNutritionRequestValidator : AbstractValidator<CreateIngredientNutritionRequest>
    {
        public CreateIngredientNutritionRequestValidator()
        {
            RuleFor(x => x.IngredientId)
                .NotEmpty().WithMessage("Id nguyên liệu là bắt buộc.")
                .GreaterThan(0).WithMessage("Id nguyên liệu phải lớn hơn 0.");

            RuleFor(x => x.NutritionIds)
                .NotEmpty().WithMessage("Danh sách Id dinh dưỡng là bắt buộc.")
                .Must(nutritionIds => nutritionIds.Distinct().Count() == nutritionIds.Count)
                .WithMessage("Mỗi Id dinh dưỡng chỉ được xuất hiện một lần.");

            RuleForEach(x => x.NutritionIds)
                .GreaterThan(0).WithMessage("Id dinh dưỡng phải lớn hơn 0.");
        }
    }
}
