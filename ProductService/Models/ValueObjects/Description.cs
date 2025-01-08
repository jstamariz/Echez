namespace ProductService.Models.ValueObjects;

public class Description
{
    public string Value { get; }

    public Description(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > 500)
            throw new ArgumentException("Description must be between 1 and 500 characters.");

        Value = value;
    }

    public override string ToString() => Value;
}

