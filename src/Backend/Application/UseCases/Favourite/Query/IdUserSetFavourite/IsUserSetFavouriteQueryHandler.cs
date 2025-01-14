using Application.CQRSInterfaces;
using Application.Result;
using Domain.Repository;

namespace Application.UseCases.Favourite.Query.IdUserSetFavourite;

public class IsUserSetFavouriteQueryHandler : IQueryHandler<IsUserSetFavouriteResult, IsUserSetFavouriteQuery>
{
    private readonly IFavouriteRepository _favouriteRepository;
    private readonly IUserRepository _userRepository;

    public IsUserSetFavouriteQueryHandler( IFavouriteRepository favouriteRepository, IUserRepository userRepository )
    {
        _favouriteRepository = favouriteRepository;
        _userRepository = userRepository;
    }

    public async Task<Result.Result<IsUserSetFavouriteResult>> HandleAsync( IsUserSetFavouriteQuery query )
    {
        Domain.Entity.User user = await _userRepository.GetByLogin( query.UserLogin );

        if ( user == null )
        {
            return Result<IsUserSetFavouriteResult>.FromError( "Unknwon user" );
        }

        IsUserSetFavouriteResult result = new()
        {
            IsSet = await _favouriteRepository.IsExist( user.Id, query.RecipeId ),
        };

        return Result<IsUserSetFavouriteResult>.FromSuccess( result );
    }
}
