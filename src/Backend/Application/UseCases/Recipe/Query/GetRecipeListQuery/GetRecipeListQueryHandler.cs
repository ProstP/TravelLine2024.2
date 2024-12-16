using System.Linq.Expressions;
using System.Net.Http.Headers;
using Application.CQRSInterfaces;
using Application.Result;
using Application.UseCases.Recipe.Dtos;
using Domain.Entity;
using Domain.Repository;

namespace Application.UseCases.Recipe.Query.GetRecipeListQuery;

public class GetRecipeListQueryHandler : IQueryHandler<List<RecipeDto>, GetRecipeListQuery>
{
    private readonly IRecipeRepository _recipeRepository;

    public GetRecipeListQueryHandler( IRecipeRepository recipeRepository )
    {
        _recipeRepository = recipeRepository;
    }

    public async Task<Result<List<RecipeDto>>> HandleAsync( GetRecipeListQuery query )
    {
        Expression<Func<Domain.Entity.Recipe, object>> orderFn = GetOrderExpression( query );

        List<Domain.Entity.Recipe> recipes = await _recipeRepository.GetList( ( query.GroupNum - 1 ) * query.Count, query.Count,
            orderFn );

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
            Image = r.Image
        } ).ToList();

        return Result<List<RecipeDto>>.FromSuccess( recipeDtos );
    }
    private Expression<Func<Domain.Entity.Recipe, object>> GetOrderExpression( GetRecipeListQuery query )
    {
        return query.OrderType == "Like"
            ? recipe => recipe.Likes.Count
            : recipe => recipe.CreatedDate;
    }
}
