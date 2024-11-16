using Application.Result;

namespace Application.CQRSInterfaces;

public interface IQueryHandler<TQuery> where TQuery : class
{
    Task<Result.Result> HandleAsync( TQuery query );
}

public interface IQueryHandler<TResult, TQuery> where TResult : class where TQuery : class
{
    Task<Result<TResult>> HandleAsync( TQuery query );
}
