using System.Linq.Expressions;
using Application.CQRSInterfaces;
using Application.ImageStore.LoadImage;
using Application.Result;
using Application.UseCases.Recipe.Dtos;
using Domain.Repository;

namespace Application.UseCases.Recipe.Query.GetRecipeListQuery;

public class GetRecipeListQueryHandler : IQueryHandler<List<RecipeDto>, GetRecipeListQuery>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IImageLoader _imageLoader;

    public GetRecipeListQueryHandler(
        IRecipeRepository recipeRepository,
        IImageLoader imageLoader )
    {
        _recipeRepository = recipeRepository;
        _imageLoader = imageLoader;
    }

    public async Task<Result<List<RecipeDto>>> HandleAsync( GetRecipeListQuery query )
    {
        try
        {

            Func<Domain.Entity.Recipe, object> orderExp = GetOrderFunc( query );
            Expression<Func<Domain.Entity.Recipe, bool>> selectExp = GetSelectExpression( query );

            List<Domain.Entity.Recipe> recipes = await _recipeRepository.GetList( ( query.GroupNum - 1 ) * query.Count, query.Count,
                orderExp, selectExp, query.IsAsc );

            List<RecipeDto> recipeDtos = recipes.Select( r => new RecipeDto()
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                CookingTime = r.CookingTime,
                PersonNum = r.PersonNum,
                Tags = r.Tags.Select( t => t.Name ).ToList(),
                CreatedDate = r.CreatedDate,
                UserId = r.UserId,
                Image = _imageLoader.Load( r.Image ),
                LikeCount = r.LikeCount,
                FavouriteCount = r.FavouriteCount,
            } ).ToList();

            return Result<List<RecipeDto>>.FromSuccess( recipeDtos );
        }
        catch ( Exception ex )
        {
            return Result<List<RecipeDto>>.FromError( ex.Message );
        }
    }

    private Expression<Func<Domain.Entity.Recipe, bool>> GetSelectExpression( GetRecipeListQuery query )
    {
        return query.SearchName != null
            ? recipe => recipe.Name.ToLower().IndexOf( query.SearchName.ToLower() ) != -1
                || recipe.Tags.Any( t => t.Name.ToLower().IndexOf( query.SearchName.ToLower() ) != -1 )
            : recipe => true;
    }

    private Func<Domain.Entity.Recipe, object> GetOrderFunc( GetRecipeListQuery query )
    {
        return query.OrderType == "Like"
            ? recipe => recipe.LikeCount
            : query.OrderType == "Favourite"
                ? recipe => recipe.FavouriteCount
                : query.OrderType == "PersonNum"
                    ? recipe => recipe.PersonNum
                    : query.OrderType == "CookingTime"
                        ? recipe => recipe.CookingTime
                        : recipe => recipe.CreatedDate;
    }
}
