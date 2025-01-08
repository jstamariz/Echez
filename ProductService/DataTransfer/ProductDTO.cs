using System;

namespace ProductService.DataTransfer;

public record ProductDTO
(
    int Id,
    string Name,
    decimal Price,
    string Description,
    string Image
);

