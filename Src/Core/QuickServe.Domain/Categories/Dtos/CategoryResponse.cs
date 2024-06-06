using QuickServe.Domain.Categories.Entities;
using QuickServe.Domain.IngredientTypes.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickServe.Domain.Categories.Dtos
{
    public class CategoryResponse
    {
        public CategoryResponse() { }
        public CategoryResponse(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            Status = category.Status;
        }
        public long Id { get; set; }
        public string? Name { get; set; }
        public int Status { get; set; }
    }
}
