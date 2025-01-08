using System;
using ProductService.Handlers.Queries;
using ProductService.Models.ValueObjects;

namespace ProductService.Tests.Queries;

public class GetAllProductsQueryTests : CQRSTest
{
    [Fact]
    public async Task ExecuteAsync_ShouldReturnAllProducts()
    {
        // Arrange
        _productContext.Products.AddRange(
            new()
            {
                Name = new ProductName("1"),
                Price = new Price(1),
                Description = new Description("1"),
                Image = new Uri("http://example.com/1.jpg")
            },
            new()
            {
                Name = new ProductName("2"),
                Price = new Price(2),
                Description = new Description("2"),
                Image = new Uri("http://example.com/2.jpg")
            }
        );
        
        await _productContext.SaveChangesAsync();

        var query = new GetAllProductsQuery(_productContext);

        // Act
        var products = await query.ExecuteAsync();

        // Assert
        Assert.Equal(2, products.Count());
    }
}