using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.Persistence;

public class ProductContext(DbContextOptions<ProductContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.OwnsOne(p => p.Name, name =>
            {
                name.Property(n => n.Value)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(100);
            });

            entity.OwnsOne(p => p.Price, price =>
            {
                price.Property(p => p.Value)
                    .HasColumnName("Price")
                    .IsRequired()
                    .HasPrecision(18, 2);
            });

            entity.OwnsOne(p => p.Description, description =>
            {
                description.Property(d => d.Value)
                    .HasColumnName("Description")
                    .HasMaxLength(500);
            });
        });
    }
}