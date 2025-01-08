using System;

namespace ProductService.Models.ValueObjects;

public class ProductName
{
    public string Value { get; }

    public ProductName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Product name cannot be empty.");

        Value = value;
    }

    public override string ToString() => Value;
}

