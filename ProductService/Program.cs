using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using ProductService.Commands;
using ProductService.CQRS;
using ProductService.DataTransfer;
using ProductService.Extensions;
using ProductService.Models;
using ProductService.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddQueries();
builder.Services.AddCommands();

var app = builder.Build();

// Map queries
app.MapGet("/api/products", async (IQuery<IEnumerable<Product>> query) =>
{
    var products = await query.ExecuteAsync();
    return Results.Ok(products);
});

app.MapGet("/api/products/{id}", async (IQuery<int, Product> query, int id) =>
{
    var product = await query.ExecuteAsync(id);
    return product == null ? Results.NotFound() : Results.Ok(product);
});

app.MapGet("/api/products/search/{name}", async (IQuery<string, IEnumerable<Product>> query, string name) =>
{
    var products = await query.ExecuteAsync(name);
    return Results.Ok(products);
});

// Map Commands
app.MapPost("/api/products", async (ICommand<ProductDTO, Product> command, ProductDTO dto) =>
{
    var output = await command.ExecuteAsync(dto);
    return Results.Created($"/api/products/{output.Result?.Id}", output.Result);
});

app.MapPut("/api/products/{id}", async (ICommand<ProductDTO, object?> command, int id, ProductDTO ProductDTO) =>
{
    if (id != ProductDTO.Id) return Results.BadRequest("Updated product id is not the same as product id parameter");

    var result = await command.ExecuteAsync(ProductDTO);
    return result.AffectedRows > 0 ? Results.NoContent() : Results.NotFound();
});

app.MapDelete("/api/products/{id}", async (ICommand<int, object?> command, int id) =>
{
    var result = await command.ExecuteAsync(id);
    return result.AffectedRows > 0 ? Results.NoContent() : Results.NotFound();
});

app.UseHttpsRedirection();
app.Run();

