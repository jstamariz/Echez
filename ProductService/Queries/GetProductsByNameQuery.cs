using System;
using Microsoft.EntityFrameworkCore;
using ProductService.CQRS;
using ProductService.Models;
using ProductService.Models.ValueObjects;
using ProductService.Persistence;

namespace ProductService.Queries;

public class GetProductsByNameQuery : IQuery<string, IEnumerable<Product>>
{
    private readonly ProductContext _context;

    public GetProductsByNameQuery(ProductContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> ExecuteAsync(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return await _context.Products
            .Where(p => p.Name.Value.Contains(name))
            .ToListAsync();
    }
}