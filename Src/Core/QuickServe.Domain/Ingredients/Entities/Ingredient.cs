﻿using System.Collections.Generic;
using QuickServe.Domain.Common;
using QuickServe.Domain.IngredientNutritions.Entities;
using QuickServe.Domain.IngredientProducts.Entities;
using QuickServe.Domain.IngredientSessions.Entities;
using QuickServe.Domain.IngredientTypes.Entities;

namespace QuickServe.Domain.Ingredients.Entities
{
    public class Ingredient : AuditableBaseEntity
    {
        public Ingredient()
        {
            IngredientProducts = new HashSet<IngredientProduct>();
            IngredientSessions = new HashSet<IngredientSession>();
            IngredientNutritions = new HashSet<IngredientNutrition>();
        }
        public Ingredient(string name, decimal price, int calo, string description, string imageUrl, long ingredientTypeId, int status, IngredientType ingredientType)
        {
            Name = name;
            Price = price;
            Calo = calo;
            Description = description;
            ImageUrl = imageUrl;
            IngredientTypeId = ingredientTypeId;
            Status = status;
            IngredientType = ingredientType;
            IngredientNutritions = new HashSet<IngredientNutrition>();
            IngredientProducts = new HashSet<IngredientProduct>();
            IngredientSessions = new HashSet<IngredientSession>(); 
        }
        public void Update(string name, decimal price, int calo, string description, long ingredientTypeId)
        {
            Name = name;
            Price = price;
            Calo = calo;
            Description = description;
            IngredientTypeId = ingredientTypeId;
        }
        public void Update(int status)
        {
            Status = status;

        }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Calo { get; set; }
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public long IngredientTypeId { get; set; }
        public int Status { get; set; }

        public virtual IngredientType IngredientType { get; set; } = null!;

        public virtual ICollection<IngredientNutrition>? IngredientNutritions { get; set; }
        public virtual ICollection<IngredientProduct> IngredientProducts { get; set; }
        public virtual ICollection<IngredientSession> IngredientSessions { get; set; }
    }
}