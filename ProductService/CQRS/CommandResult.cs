using System;

namespace ProductService.CQRS;

public record CommandResult<T> (int AffectedRows, T? Result = null) where T : class?;