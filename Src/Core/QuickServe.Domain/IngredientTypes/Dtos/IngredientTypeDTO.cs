using QuickServe.Domain.Categories.Entities;
using QuickServe.Domain.IngredientTypes.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickServe.Domain.IngredientTypes.Dtos
{
    public class IngredientTypeDTO
    {
        public IngredientTypeDTO() { }
        public IngredientTypeDTO(IngredientType ingredientType) {
            Id = ingredientType.Id;
            Name = ingredientType.Name;
            Status = ingredientType.Status;
            Created = ingredientType.Created;
            CreatedBy = ingredientType.CreatedBy;
            LastModified = ingredientType.LastModified ?? null;  // Xử lý giá trị NULL
            LastModifiedBy = ingredientType.LastModifiedBy ?? null;
        }
        public long Id { get; set; }
        public string? Name { get; set; }
        public int Status { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime Created { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
