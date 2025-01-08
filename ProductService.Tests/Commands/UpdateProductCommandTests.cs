using System;
using ProductService.DataTransfer;
using ProductService.Handlers.Commands;
using ProductService.Models;
using ProductService.Models.ValueObjects;

namespace ProductService.Tests.Commands;

public class UpdateProductCommandTests : CQRSTest
{
    [Fact]
    public async Task ExecuteAsync_ShouldUpdateProduct()
    {
        // Arrange
        var product = new Product()
        {
            Name = new ProductName("Original Name"),
            Price = new Price(50m),
            Description = new Description("Original Description"),
            Image = new Uri("http://example.com/original.jpg")
        };
        _productContext.Products.Add(product);
        await _productContext.SaveChangesAsync();

        var command = new UpdateProductCommand(_productContext);
        var productDto = new ProductDTO(

            product.Id,
            new("Updated Name"),
            new(100),
            new("Updated Description"),
            new("http://example.com/updated.jpg")
        );

        // Act
        var result = await command.ExecuteAsync(productDto);

        // Assert
        var updatedProduct = await _productContext.Products.FindAsync(product.Id);
        Assert.Equal(productDto.Name, updatedProduct?.Name.Value);
        Assert.Equal(productDto.Price, updatedProduct?.Price.Value);
        Assert.Equal(productDto.Description, updatedProduct?.Description.Value);
        Assert.Equal(productDto.Image, updatedProduct?.Image?.AbsoluteUri);
    }
}
