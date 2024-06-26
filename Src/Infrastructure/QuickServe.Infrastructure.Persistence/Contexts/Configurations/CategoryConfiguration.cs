﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickServe.Domain.Categories.Entities;

namespace QuickServe.Infrastructure.Persistence.Contexts.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> entity)
    {
        entity.ToTable("Category");

        entity.Property(e => e.CreatedBy)
            .HasMaxLength(40)
            .IsUnicode(false)
            .IsRequired();

        entity.Property(e => e.Created).HasColumnType("timestamp with time zone").IsRequired();



        entity.Property(e => e.LastModifiedBy)
            .HasMaxLength(40);
      

        entity.Property(e => e.LastModified).HasColumnType("timestamp with time zone");

        entity.Property(e => e.Name)
            .HasMaxLength(40)
            .IsUnicode(false)
            .IsRequired();
    }
}