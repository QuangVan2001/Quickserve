using QuickServe.Domain.Categories.Dtos;
using QuickServe.Domain.ProductTemplates.Entities;
using System;

namespace QuickServe.Domain.ProductTemplates.Dtos
{
    public class ProductTemplateDto
    {
        public ProductTemplateDto()
        {
        }

        public ProductTemplateDto(ProductTemplate productTemplate)
        {
            Id = productTemplate.Id;
            CategoryId = productTemplate.CategoryId;
            Name = productTemplate.Name;
            Quantity = productTemplate.Quantity ?? 0;
            Size = productTemplate.Size;
            ImageUrl = productTemplate.ImageUrl;
            Price = productTemplate.Price;
            Description = productTemplate.Description;
            Status = productTemplate.Status;
            Created = productTemplate.Created;
            CreatedBy = productTemplate.CreatedBy;
            LastModified = productTemplate.LastModified ?? null;  // Xử lý giá trị NULL
            LastModifiedBy = productTemplate.LastModifiedBy ?? null;
            Category = new CategoryResponse(productTemplate.Category);
        }

        public long Id { get; set; }
        public long CategoryId { get;  set; }
        public string Name { get;  set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public int Status { get; set; }
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; } 
        public string CreatedBy { get; set; } = null!;
        public DateTime Created { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public virtual CategoryResponse Category { get; set; } = null!;
    }
}