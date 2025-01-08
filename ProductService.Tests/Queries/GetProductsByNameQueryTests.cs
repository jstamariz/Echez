using System;
using ProductService.Handlers.Queries;
using ProductService.Models;
using ProductService.Models.ValueObjects;

namespace ProductService.Tests.Queries;

public class GetProductsByNameQueryTests : CQRSTest
{
    [Fact]
    public async Task ExecuteAsync_ShouldReturnMatchingProducts()
    {
        // Arrange
        _productContext.Products.AddRange(
            new()
            {
                Name = new("Apple iPhone"),
                Price = new(999.99m),
                Description = new("Smartphone"),
                Image = new("http://example.com/iphone.jpg")
            },
            new()
            {
                Name = new("Apple MacBook"),
                Price = new(1299.99m),
                Description = new("Laptop"),
                Image = new("http://example.com/macbook.jpg")
            },
            new()
            {
                Name = new("Samsung Galaxy"),
                Price = new(899.99m),
                Description = new("Smartphone"),
                Image = new("http://example.com/galaxy.jpg")
            }
        );
        await _productContext.SaveChangesAsync();

        var query = new GetProductsByNameQuery(_productContext);

        // Act
        var result = await query.ExecuteAsync("Apple");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.All(result, p => Assert.Contains("Apple", p.Name.Value));
    }

    [Fact]
    public async Task ExecuteAsync_ShouldReturnEmpty_WhenNoMatchingProducts()
    {
        // Arrange
        var query = new GetProductsByNameQuery(_productContext);

        // Act
        var result = await query.ExecuteAsync("NonExistentProduct");

        // Assert
        Assert.Empty(result);
    }
}