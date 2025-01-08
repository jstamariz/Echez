using System;

namespace ProductService.CQRS;

public interface IQuery<TParameters, TResult> where TResult: class?
{
    Task<TResult> ExecuteAsync(TParameters parameters);
}

public interface IQuery<TResult>
{
    Task<TResult?> ExecuteAsync();
}