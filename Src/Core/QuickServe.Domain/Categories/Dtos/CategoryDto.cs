using System;
using QuickServe.Domain.Categories.Entities;

namespace QuickServe.Domain.Categories.Dtos
{
    public class CategoryDto
    {
        public CategoryDto(){}

        public CategoryDto(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            Created = category.Created;
            CreatedBy = category.CreatedBy;
         
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
      
        
    }
}