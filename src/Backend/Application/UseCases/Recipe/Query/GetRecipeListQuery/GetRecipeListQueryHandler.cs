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
    private readonly ILikeRepository _likeRepository;

    public GetRecipeListQueryHandler(
        IRecipeRepository recipeRepository,
        IImageLoader imageLoader,
        ILikeRepository likeRepository )
    {
        _recipeRepository = recipeRepository;
        _imageLoader = imageLoader;
        _likeRepository = likeRepository;
    }

    public async Task<Result<List<RecipeDto>>> HandleAsync( GetRecipeListQuery query )
    {
        Expression<Func<Domain.Entity.Recipe, object>> orderExp = GetOrderExpression( query );
        Expression<Func<Domain.Entity.Recipe, bool>> selectExp = GetSelectExpression( query );

        List<Domain.Entity.Recipe> recipes = await _recipeRepository.GetList( ( query.GroupNum - 1 ) * query.Count, query.Count,
            orderExp, selectExp, query.IsAsc );

        RecipeDto[] recipeDtos = await Task.WhenAll( recipes.Select( async r => new RecipeDto()
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
            LikeCount = await _likeRepository.GetByRecipeId( r.Id ),
        } ) );

        return Result<List<RecipeDto>>.FromSuccess( recipeDtos.ToList() );
    }

    private Expression<Func<Domain.Entity.Recipe, bool>> GetSelectExpression( GetRecipeListQuery query )
    {
        return query.SearchName != null
            ? recipe => recipe.Name.ToLower().IndexOf( query.SearchName.ToLower() ) != -1
                || recipe.Tags.Any( t => t.Name.ToLower().IndexOf( query.SearchName.ToLower() ) != -1 )
            : recipe => true;
    }

    private Expression<Func<Domain.Entity.Recipe, object>> GetOrderExpression( GetRecipeListQuery query )
    {
        return query.OrderType == "Like"
            ? recipe => recipe.LikeCount
            : query.OrderType == "Favourite"
                ? recipe => recipe.Favourites.Count
                : query.OrderType == "PersonNum"
                    ? recipe => recipe.PersonNum
                    : query.OrderType == "CookingTime"
                        ? recipe => recipe.CookingTime
                        : recipe => recipe.CreatedDate;
    }
}
