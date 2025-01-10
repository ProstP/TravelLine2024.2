using Application.CQRSInterfaces;
using Application.Result;
using Domain.Repository;

namespace Application.UseCases.Like.Query.IsUserSetLike;

public class IsUserSetLikeQueryHandler : IQueryHandler<IsUserSetLikeQueryResult, IsUserSetLikeQuery>
{
    private readonly ILikeRepository _likeRepository;
    private readonly IUserRepository _userRepository;

    public IsUserSetLikeQueryHandler( ILikeRepository likeRepository, IUserRepository userRepository )
    {
        _likeRepository = likeRepository;
        _userRepository = userRepository;
    }

    public async Task<Result<IsUserSetLikeQueryResult>> HandleAsync( IsUserSetLikeQuery query )
    {
        Domain.Entity.User user = await _userRepository.GetByLogin( query.UserLogin );

        if ( user == null )
        {
            return Result<IsUserSetLikeQueryResult>.FromError( "Unknwon user" );
        }

        IsUserSetLikeQueryResult result = new()
        {
            IsSet = await _likeRepository.IsExist( user.Id, query.RecipeId ),
        };

        return Result<IsUserSetLikeQueryResult>.FromSuccess( result );
    }
}