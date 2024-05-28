using System.Collections.Generic;
using QuickServe.Domain.Categories.Entities;
using QuickServe.Domain.Common;
using QuickServe.Domain.Products.Entities;
using QuickServe.Domain.Stores.Entities;
using QuickServe.Domain.TemplateSteps.Entities;

namespace QuickServe.Domain.ProductTemplates.Entities
{
    public class ProductTemplate : AuditableBaseEntity
    {
        public long CategoryId { get; private set; }
        public string Name { get; private set; }
        public int? Quantity { get; set; }
        public string Size { get; set; }
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<ProDucts> Products { get; set; }
        public virtual ICollection<TemplateStep> TemplateSteps { get; set; }
    }
}