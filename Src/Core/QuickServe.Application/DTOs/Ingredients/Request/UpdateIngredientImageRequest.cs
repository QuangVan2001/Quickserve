using FluentValidation;
using Microsoft.AspNetCore.Http;
using QuickServe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.DTOs.Ingredients.Request
{
    public class UpdateIngredientImageRequest
    {
        public IFormFile Image { get; set; }
    }
    public class UpdateIngredientImageValidator : AbstractValidator<UpdateIngredientImageRequest>
    {
        public UpdateIngredientImageValidator(ITranslator translator)
        {
            RuleFor(x => x.Image)
                .NotNull().WithMessage(translator["Image is required."])
                .Must(BeAValidImage).WithMessage(translator["Only image files are allowed."])
                .Must(BeAValidSize).WithMessage(translator["Image size must be less than 2MB."]);

        }

        private bool BeAValidImage(IFormFile file)
        {
            if (file == null) return false;

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = System.IO.Path.GetExtension(file.FileName).ToLowerInvariant();

            return allowedExtensions.Contains(extension);
        }

        private bool BeAValidSize(IFormFile file)
        {
            if (file == null) return false;

            const int maxSizeInBytes = 2 * 1024 * 1024; // 2 MB
            return file.Length <= maxSizeInBytes;
        }
    }
}
