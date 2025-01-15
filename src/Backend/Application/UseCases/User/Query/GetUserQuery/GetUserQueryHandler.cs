using Application.CQRSInterfaces;
using Application.Result;
using Application.UseCases.User.Dtos;
using Domain.Repository;

namespace Application.UseCases.User.Query.GetUserQuery;

public class GetUserQueryHandler : IQueryHandler<GetUserQueryDto, GetUserQuery>
{
    private readonly IUserRepository _userRepository;
    private readonly IRecipeRepository _recipeRepository;
    private readonly ILikeRepository _likeRepository;
    private readonly IFavouriteRepository _favouriteRepository;

    public GetUserQueryHandler(
        IUserRepository userRepository,
        IRecipeRepository recipeRepository,
        ILikeRepository likeRepository,
        IFavouriteRepository favouriteRepository )
    {
        _userRepository = userRepository;
        _recipeRepository = recipeRepository;
        _likeRepository = likeRepository;
        _favouriteRepository = favouriteRepository;
    }

    public async Task<Result<GetUserQueryDto>> HandleAsync( GetUserQuery query )
    {
        Domain.Entity.User user = await _userRepository.GetByLogin( query.Login );

        if ( user == null )
        {
            return Result<GetUserQueryDto>.FromError( "Unknown user" );
        }

        GetUserQueryDto result = new()
        {
            Name = user.Name,
            Login = user.Login,
            About = user.About,
            RecipeCount = await _recipeRepository.GetRecipeCountByUser( user.Id ),
            LikeCount = await _likeRepository.GetByUserId( user.Id ),
            FavouriteCount = await _favouriteRepository.GetByUserId( user.Id ),
        };

        return Result<GetUserQueryDto>.FromSuccess( result );
    }
}
