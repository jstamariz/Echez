using System;
using ProductService.CQRS;
using ProductService.Persistence;

namespace ProductService.Commands;

public class DeleteProductCommand : ICommand<int, object?>
{
    private readonly ProductContext _context;

    public DeleteProductCommand(ProductContext context)
    {
        _context = context;
    }

    public async Task<CommandResult<object?>> ExecuteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        
        if (product is null) return new(0);
        
        _context.Products.Remove(product);
        var affectedRows = await _context.SaveChangesAsync();

        return new(affectedRows);
    }
}