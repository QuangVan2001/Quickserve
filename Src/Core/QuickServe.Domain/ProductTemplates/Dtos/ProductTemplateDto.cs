using QuickServe.Domain.ProductTemplates.Entities;

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
        }

        public long Id { get; set; }
        public long CategoryId { get;  set; }
        public string Name { get;  set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public long StoreId { get; set; }
        public string Description { get; set; }
    }
}