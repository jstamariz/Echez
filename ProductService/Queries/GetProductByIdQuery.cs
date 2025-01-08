using System;
using ProductService.CQRS;
using ProductService.Models;
using ProductService.Persistence;

namespace ProductService.Queries;

public class GetProductByIdQuery : IQuery<int, Product>
{
    private readonly ProductContext _context;

    public GetProductByIdQuery(ProductContext context)
    {
        _context = context;
    }

    public Task<Product> ExecuteAsync(int id)
    {
        throw new NotImplementedException();
    }
}