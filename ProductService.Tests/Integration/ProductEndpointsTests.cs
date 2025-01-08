using System;
using System.Net;
using System.Net.Http.Json;
using ProductService.DataTransfer;
using ProductService.Models;

namespace ProductService.Tests.Integration;

public class ProductEndpointsTests 
{

    [Fact]
    public async Task GetProducts_ShouldReturnEmptyList_WhenNoProductsExist()
    {
        await using var application = new PlaygroundApplication();
        using var client = application.CreateClient();
        // Act
        var response = await client.GetAsync("/api/products");

        // Assert
        response.EnsureSuccessStatusCode();
        var products = await response.Content.ReadFromJsonAsync<IEnumerable<Product>>();
        Assert.NotNull(products);
        Assert.Empty(products);
    }

    [Fact]
    public async Task CreateProduct_ShouldReturnCreatedProduct()
    {
        // Arrange

        await using var application = new PlaygroundApplication();
        using var client = application.CreateClient();

        var newProduct = new ProductDTO
        (
            0,
            "Test Product",
            49.99m,
            "Test Description",
            "http://example.com/image.jpg"
        );

        // Act
        var response = await client.PostAsJsonAsync("/api/products", newProduct);

        // Assert
        response.EnsureSuccessStatusCode();
        var createdProduct = await response.Content.ReadFromJsonAsync<Product>();
        Assert.NotNull(createdProduct);
        Assert.Equal(newProduct.Name, createdProduct.Name.Value);
    }

    [Fact]
    public async Task GetProductById_ShouldReturnProduct_WhenProductExists()
    {
        // Arrange

        await using var application = new PlaygroundApplication();
        using var client = application.CreateClient();

        var newProduct = new ProductDTO
        (
            0,
            "Existing Product",
            29.99m,
            "Existing Description",
            "http://example.com/image.jpg"
        );

        var postResponse = await client.PostAsJsonAsync("/api/products", newProduct);
        var createdProduct = await postResponse.Content.ReadFromJsonAsync<Product>();

        // Act
        var getResponse = await client.GetAsync($"/api/products/{createdProduct?.Id}");

        // Assert
        getResponse.EnsureSuccessStatusCode();
        var product = await getResponse.Content.ReadFromJsonAsync<Product>();
        Assert.NotNull(product);
        Assert.Equal(createdProduct?.Id, product.Id);
    }

    [Fact]
    public async Task UpdateProduct_ShouldReturnNoContent_WhenProductIsUpdated()
    {
        // Arrange

        await using var application = new PlaygroundApplication();
        using var client = application.CreateClient();

        var newProduct = new ProductDTO
        (
            0,
            "Product to Update",
            59.99m,
            "Original Description",
            "http://example.com/image.jpg"
        );

        var postResponse = await client.PostAsJsonAsync("/api/products", newProduct);
        var createdProduct = await postResponse.Content.ReadFromJsonAsync<Product>();

        var updatedProduct = new ProductDTO
        (
            createdProduct?.Id ?? 0,
            "Updated Product",
            79.99m,
            "Updated Description",
            "http://example.com/updated-image.jpg"
        );

        // Act
        var putResponse = await client.PutAsJsonAsync($"/api/products/{createdProduct?.Id}", updatedProduct);

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, putResponse.StatusCode);

        var getResponse = await client.GetAsync($"/api/products/{createdProduct?.Id}");
        var product = await getResponse.Content.ReadFromJsonAsync<Product>();
        Assert.Equal(updatedProduct.Name, product?.Name.Value);
        Assert.Equal(updatedProduct.Price, product?.Price.Value);
    }

    [Fact]
    public async Task DeleteProduct_ShouldReturnNoContent_WhenProductIsDeleted()
    {
        // Arrange

        await using var application = new PlaygroundApplication();
        using var client = application.CreateClient();

        var newProduct = new ProductDTO
        (
            0,
            "Product to Delete",
            39.99m,
            "Description",
            "http://example.com/image.jpg"
        );

        var postResponse = await client.PostAsJsonAsync("/api/products", newProduct);
        var createdProduct = await postResponse.Content.ReadFromJsonAsync<Product>();

        // Act
        var deleteResponse = await client.DeleteAsync($"/api/products/{createdProduct?.Id}");

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

        var getResponse = await client.GetAsync($"/api/products/{createdProduct?.Id}");
        Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
    }
}