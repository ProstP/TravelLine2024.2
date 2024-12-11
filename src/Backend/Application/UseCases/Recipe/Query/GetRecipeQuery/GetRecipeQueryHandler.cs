using Application.CQRSInterfaces;
using Application.Result;
using Application.UseCases.Recipe.Dtos;
using Domain.Repository;

namespace Application.UseCases.Recipe.Query.GetRecipeQuery;

public class GetRecipeQueryHandler : IQueryHandler<RecipeDto, GetRecipeQuery>
{
    private readonly IRecipeRepository _recipeRepository;

    public GetRecipeQueryHandler( IRecipeRepository recipeRepository )
    {
        _recipeRepository = recipeRepository;
    }

    public async Task<Result<RecipeDto>> HandleAsync( GetRecipeQuery query )
    {
        Domain.Entity.Recipe recipe = await _recipeRepository.Get( query.RecipeId );

        if ( recipe == null )
        {
            return Result<RecipeDto>.FromError( "Unknown recipe" );
        }

        RecipeDto recipeDto = new()
        {
            Id = recipe.Id,
            Name = recipe.Name,
            Description = recipe.Description,
            CookingTime = recipe.CookingTime,
            PersonNum = recipe.PersonNum,
            Image = recipe.Image,
            CreatedDate = recipe.CreatedDate,
            Ingredients = recipe.Ingredients
                .Select( i =>
                new IngredientDto()
                {
                    Id = i.Id,
                    Header = i.Header,
                    SubIngredients = i.SubIngredients,
                } ).ToList(),
            RecipeSteps = recipe.Steps
                .Select( rs =>
                new RecipeStepDto()
                {
                    Id = rs.Id,
                    Description = rs.Description,
                    StepNum = rs.StepNum,
                } ).ToList(),
            Tags = recipe.Tags.Select( t => t.Name ).ToList()
        };

        return Result<RecipeDto>.FromSuccess( recipeDto );
    }
}
