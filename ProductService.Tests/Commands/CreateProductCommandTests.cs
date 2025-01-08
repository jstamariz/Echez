using System;
using ProductService.DataTransfer;
using ProductService.Handlers.Commands;

namespace ProductService.Tests.Commands;

public class CreateProductCommandTests : CQRSTest
{
    [Fact]
    public async Task ExecuteAsync_ShouldCreateProduct()
    {
        // Arrange
        var command = new CreateProductCommand(_productContext);
        var productDto = new ProductDTO(0, new("Test Product"), new(99.99), new("Test Description"), new("http://example.com/image.jpg"));
        
        // Act
        var output = await command.ExecuteAsync(productDto);

        // Assert
        Assert.NotNull(output.Result);
        Assert.Equal(productDto.Name, output.Result.Name.Value);
        Assert.Equal(productDto.Price, output.Result.Price.Value);
        Assert.Equal(productDto.Description, output.Result.Description.Value);
    }
}