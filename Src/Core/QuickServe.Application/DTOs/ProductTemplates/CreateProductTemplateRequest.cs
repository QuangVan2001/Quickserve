using FluentValidation;
using Microsoft.AspNetCore.Http;
using QuickServe.Application.DTOs.Ingredients.Request;
using QuickServe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.DTOs.ProductTemplates
{
    public class CreateProductTemplateRequest
    {
        public long CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string Size { get; set; }
        public IFormFile Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
    }

    public class CreateProductTemplateValidator : AbstractValidator<CreateProductTemplateRequest>
    {
        public CreateProductTemplateValidator(ITranslator translator)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(translator["Name is required."])
                .Length(2, 40).WithMessage(translator["Name must be between 2 and 40 characters."]);

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage(translator["Price must be greater than 0."]);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(translator["Description is required."])
                .MaximumLength(200).WithMessage(translator["Description cannot exceed 200 characters."]);

            RuleFor(x => x.Image)
                .NotNull().WithMessage(translator["Image is required."])
                .Must(BeAValidImage).WithMessage(translator["Only image files are allowed."])
                .Must(BeAValidSize).WithMessage(translator["Image size must be less than 2MB."]);

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage(translator["CategoryId must be greater than 0."]);
            
            RuleFor(x => x.Size)
                .NotEmpty()
                .NotNull()
                .MaximumLength(10).WithMessage(translator["Size must not exceed 10 characters."]);
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
