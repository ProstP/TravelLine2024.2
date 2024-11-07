using Application.Result;

namespace Application.CQRSInterfaces;
public interface ICommandHandler<TCommand> where TCommand : class
{
    Task<Result.Result> HandleAsync( TCommand command );
}

public interface ICommandHandler<TResult, TCommand>
where TResult : class
where TCommand : class
{
    Task<Result<TResult>> HandleAsync( TCommand command );
}
