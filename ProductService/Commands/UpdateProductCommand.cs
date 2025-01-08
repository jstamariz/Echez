using System;
using Microsoft.EntityFrameworkCore;
using ProductService.CQRS;
using ProductService.DataTransfer;
using ProductService.Models.ValueObjects;
using ProductService.Persistence;

namespace ProductService.Commands;

public class UpdateProductCommand(ProductContext context) : ICommand<ProductDTO, object?>
{
    private readonly ProductContext _context = context;

    public async Task<CommandResult<object?>> ExecuteAsync(ProductDTO dto)
    {
        var product = await _context.Products.FindAsync(dto.Id);
        
        if (product is null) return new(0);

        product.Name = new ProductName(dto.Name);
        product.Price = new Price(dto.Price);
        product.Description = new Description(dto.Description);
        product.Image = new Uri(dto.Image);

        _context.Entry(product).State = EntityState.Modified;
        var affectedRows = await _context.SaveChangesAsync();

        return new(affectedRows);
    }
}
