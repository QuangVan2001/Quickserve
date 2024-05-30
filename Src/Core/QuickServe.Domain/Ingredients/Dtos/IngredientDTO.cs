﻿using QuickServe.Domain.Ingredients.Entities;
using QuickServe.Domain.IngredientTypes.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickServe.Domain.Ingredients.Dtos
{
    public class IngredientDTO
    {
        public IngredientDTO() { }
        public IngredientDTO(Ingredient ingredient) { 
            Id = ingredient.Id;
            Name = ingredient.Name;
            Price = ingredient.Price;
            Calo = ingredient.Calo;
            Description = ingredient.Description;
            ImageUrl = ingredient.ImageUrl;
            IngredientTypeId = ingredient.IngredientTypeId;
            Status = ingredient.Status;
            IngredientType = new SimpleIngredietTypeRespone(ingredient.IngredientType);
            Created = ingredient.Created;
            CreatedBy = ingredient.CreatedBy;
            LastModified = ingredient.LastModified ?? null;  // Xử lý giá trị NULL
            LastModifiedBy = ingredient.LastModifiedBy ?? null;
        }
        public long Id { get; set; }    
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Calo { get; set; }
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public long IngredientTypeId { get; set; }
        public int Status { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public virtual SimpleIngredietTypeRespone IngredientType { get; set; } = null!;

    }

}
