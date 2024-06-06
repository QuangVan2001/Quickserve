using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickServe.Domain.IngredientProducts.Entities;

namespace QuickServe.Infrastructure.Persistence.Contexts.Configurations;

public class IngredientProductsConfiguration : IEntityTypeConfiguration<IngredientProduct>
{
    public void Configure(EntityTypeBuilder<IngredientProduct> entity)
    {
        
        entity.HasKey(e => e.Id);

        // Properties Configuration
        entity.Property(e => e.Quantity).IsRequired();
// Ingredient to IngredientProducts
        entity.HasOne(ip => ip.Ingredient) // IngredientProduct has one Ingredient
            .WithMany(i => i.IngredientProducts) // Ingredient has many IngredientProducts
            .HasForeignKey(ip => ip.IngredientId); // ForeignKey in IngredientProduct linking to Ingredient

        // Products to IngredientProducts
        entity.HasOne(ip => ip.Product) // IngredientProduct has one Product
            .WithMany(p => p.IngredientProducts) // Product has many IngredientProducts
            .HasForeignKey(ip => ip.ProductId); // Foreig
    }

     
    }
