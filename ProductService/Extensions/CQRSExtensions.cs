using System;
using ProductService.Commands;
using ProductService.Queries;
using ProductService.CQRS;
using ProductService.DataTransfer;
using ProductService.Models;

namespace ProductService.Extensions;

public static class CQRSExtensions
{
    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        services.AddScoped<ICommand<ProductDTO, Product>, CreateProductCommand>();
        services.AddScoped<ICommand<ProductDTO, object?>, UpdateProductCommand>();
        services.AddScoped<ICommand<int, object?>, DeleteProductCommand>();

        return services;
    }

    public static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.AddScoped<IQuery<IEnumerable<Product>>, GetAllProductsQuery>();
        services.AddScoped<IQuery<int, Product>, GetProductByIdQuery>();
        services.AddScoped<IQuery<string, IEnumerable<Product>>, GetProductsByNameQuery>();

        return services;
    }
}
