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
            Name = recipe.Name,
            Description = recipe.Description,
            CookingTime = recipe.CookingTime,
            PersonNum = recipe.PersonNum,
            Image = recipe.Image,
        };

        foreach ( Domain.Entity.Ingredient ingredient in recipe.Ingredients )
        {
            recipeDto.Ingredients.Add( new IngredientDto()
            {
                Header = ingredient.Header,
                SubIngredients = ingredient.SubIngredients,
            } );
        }

        foreach ( Domain.Entity.RecipeStep recipeStep in recipe.Steps )
        {
            recipeDto.RecipeSteps.Add( new RecipeStepDto()
            {
                StepNum = recipeStep.StepNum,
                Description = recipeStep.Description,
            } );
        }

        return Result<RecipeDto>.FromSuccess( recipeDto );
    }
}
