using System;

namespace ProductService.CQRS;

public interface IQuery<TParameters, TResult>
{
    Task<TResult> ExecuteAsync(TParameters parameters);
}

public interface IQuery<TResult>
{
    Task<TResult> ExecuteAsync();
}