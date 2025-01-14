using Application.CQRSInterfaces;
using Application.Result;
using Domain.Repository;

namespace Application.UseCases.Favourite.Query.GetFavouriteCount;

public class GetFavouriteCountQueryHandler : IQueryHandler<GetFavouriteCountResult, GetFavouriteCountQuery>
{
    private readonly IFavouriteRepository _favouriteRepository;

    public GetFavouriteCountQueryHandler( IFavouriteRepository favouriteRepository )
    {
        _favouriteRepository = favouriteRepository;
    }

    public async Task<Result<GetFavouriteCountResult>> HandleAsync( GetFavouriteCountQuery query )
    {
        int count;

        try
        {
            if ( query.FromRecipe )
            {
                count = await _favouriteRepository.GetByRecipeId( query.Id );
            }
            else
            {
                count = await _favouriteRepository.GetByUserId( query.Id );
            }

            GetFavouriteCountResult result = new()
            {
                Count = count,
            };

            return Result<GetFavouriteCountResult>.FromSuccess( result );
        }
        catch ( Exception ex )
        {
            return Result<GetFavouriteCountResult>.FromError( ex.Message );
        }
    }
}
