using System;

namespace ProductService.CQRS;

public interface ICommand<TObject, TResult> where TResult : class?
{
    Task<CommandResult<TResult>> ExecuteAsync(TObject obj);
}