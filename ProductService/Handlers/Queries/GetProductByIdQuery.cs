using System;
using ProductService.CQRS;
using ProductService.Models;
using ProductService.Persistence;

namespace ProductService.Handlers.Queries;

public class GetProductByIdQuery : IQuery<int, Product?>
{
    private readonly ProductContext _context;

    public GetProductByIdQuery(ProductContext context)
    {
        _context = context;
    }

    public async Task<Product?> ExecuteAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }
}