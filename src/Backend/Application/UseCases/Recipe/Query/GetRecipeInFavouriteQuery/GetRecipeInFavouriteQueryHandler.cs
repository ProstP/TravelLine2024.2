using Application.CQRSInterfaces;
using Application.ImageStore.LoadImage;
using Application.Result;
using Application.UseCases.Recipe.Dtos;
using Domain.Repository;

namespace Application.UseCases.Recipe.Query.GetRecipeInFavouriteQuery;

public class GetRecipeInFavouriteQueryHandler : IQueryHandler<List<RecipeDto>, GetRecipeInFavouriteQuery>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUserRepository _userRepository;
    private readonly IImageLoader _imageLoader;

    public GetRecipeInFavouriteQueryHandler(
        IRecipeRepository recipeRepository,
        IUserRepository userRepository,
        IImageLoader imageLoader )
    {
        _recipeRepository = recipeRepository;
        _userRepository = userRepository;
        _imageLoader = imageLoader;
    }

    public async Task<Result<List<RecipeDto>>> HandleAsync( GetRecipeInFavouriteQuery query )
    {
        Domain.Entity.User user = await _userRepository.GetByLogin( query.UserLogin );

        if ( user == null )
        {
            return Result<List<RecipeDto>>.FromError( "Unknown user" );
        }

        List<Domain.Entity.Recipe> recipes = await _recipeRepository.GetByUserFavourite( ( query.GroupNum - 1 ) * query.Count, query.Count, user.Id );

        List<RecipeDto> result = recipes.Select( r => new RecipeDto()
        {
            Id = r.Id,
            Name = r.Name,
            Description = r.Description,
            CookingTime = r.CookingTime,
            PersonNum = r.PersonNum,
            Image = _imageLoader.Load( r.Image ),
            CreatedDate = r.CreatedDate,
            UserId = user.Id,
            Tags = r.Tags.Select( t => t.Name ).ToList(),
            LikeCount = r.LikeCount,
            FavouriteCount = r.FavouriteCount,
        } ).ToList();

        return Result<List<RecipeDto>>.FromSuccess( result );
    }
}
