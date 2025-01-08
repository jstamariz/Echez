using System;
using ProductService.Handlers.Commands;
using ProductService.Models;
using ProductService.Models.ValueObjects;

namespace ProductService.Tests.Commands;
public class DeleteProductCommandTests : CQRSTest
{
    [Fact]
    public async Task ExecuteAsync_ShouldDeleteProduct()
    {
        // Arrange        
        var product = new Product()
        {
            Name = new ProductName("Name"),
            Price = new Price(50m),
            Description = new Description("Description"),
            Image = new Uri("http://example.com/photo.jpg")
        };

        _productContext.Products.Add(product);
        await _productContext.SaveChangesAsync();

        var command = new DeleteProductCommand(_productContext);

        // Act
        var result = await command.ExecuteAsync(product.Id);

        // Assert
        Assert.Null(await _productContext.Products.FindAsync(product.Id));
    }
}