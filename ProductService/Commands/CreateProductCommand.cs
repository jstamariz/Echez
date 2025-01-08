using System;
using ProductService.CQRS;
using ProductService.DataTransfer;
using ProductService.Models;
using ProductService.Models.ValueObjects;
using ProductService.Persistence;

namespace ProductService.Commands;

public class CreateProductCommand(ProductContext context) : ICommand<ProductDTO, Product>
{
    private readonly ProductContext _context = context;

    public async Task<CommandResult<Product>> ExecuteAsync(ProductDTO productDto)
    {
        var product = new Product()
        {
            Name = new ProductName(productDto.Name),
            Price = new Price(productDto.Price),
            Description = new Description(productDto.Description),
            Image = new Uri(productDto.Image)
        };

        _context.Products.Add(product);
        var AffectedRows = await _context.SaveChangesAsync();

        return new (AffectedRows, product);
    }
}