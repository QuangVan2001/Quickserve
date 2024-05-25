namespace QuickServe.Domain.ProductTemplates.Dtos
{
    public class ProductTemplateDto
    {
        public ProductTemplateDto()
        {
        }

        public ProductTemplateDto(long id, long categoryId, string name, int quantity, string size, string imageUrl, decimal price, long storeId, string description)
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
            Quantity = quantity;
            Size = size;
            ImageUrl = imageUrl;
            Price = price;
            StoreId = storeId;
            Description = description;
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