using System;
using Microsoft.EntityFrameworkCore;
using ProductService.CQRS;
using ProductService.Models;
using ProductService.Persistence;

namespace ProductService.Queries;

public class GetAllProductsQuery : IQuery<IEnumerable<Product>>
{
    private readonly ProductContext _context;

    public GetAllProductsQuery(ProductContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> ExecuteAsync()
    {
        return await _context.Products.ToListAsync();
    }
}