using System;
using System.ComponentModel.DataAnnotations;
using QuickServe.Domain.Categories.Entities;
using QuickServe.Domain.Stores.Entities;


namespace QuickServe.Domain.Categories.Dtos
{
    public class CategoryDto
    {
        public CategoryDto(){}

        public CategoryDto(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            Status = category.Status;
            Created = category.Created;
            CreatedBy = category.CreatedBy;
            LastModified = category.LastModified?? null;  // Xử lý giá trị NULL
            LastModifiedBy = category.LastModifiedBy ?? null;
        }
        public long Id { get; set; }
        public string? Name { get; set; } 
        public int Status { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        
    }
}