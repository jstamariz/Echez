using System;
using ProductService.Handlers.Queries;
using ProductService.Models;
using ProductService.Models.ValueObjects;

namespace ProductService.Tests.Queries;

public class GetProductByIdQueryTests : CQRSTest
{
    [Fact]
    public async Task ExecuteAsync_ShouldReturnProduct_WhenProductExists()
    {
        // Arrange

        Product product = new()
        {
            Name = new ProductName("Test"),
            Price = new Price(100),
            Description = new Description("Test"),
            Image = new Uri("http://example.com/Test.jpg")
        };

        _productContext.Products.Add(product);

        await _productContext.SaveChangesAsync();

        var query = new GetProductByIdQuery(_productContext);

        // Act
        var result = await query.ExecuteAsync(product.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(product.Id, result.Id);
        Assert.Equal("Test", product.Name.Value);
    }

    [Fact]
    public async Task ExecuteAsync_ShouldReturnNull_WhenProductDoesNotExist()
    {
        // Arrange
        var query = new GetProductByIdQuery(_productContext);

        // Act
        var result = await query.ExecuteAsync(999); // Non-existent ID

        // Assert
        Assert.Null(result);
    }
}
