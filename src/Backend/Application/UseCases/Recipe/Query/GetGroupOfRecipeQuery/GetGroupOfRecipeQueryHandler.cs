using Application.CQRSInterfaces;
using Application.Result;
using Application.UseCases.Recipe.Dtos;
using Domain.Entity;
using Domain.Repository;

namespace Application.UseCases.Recipe.Query.GetGroupOfRecipeQuery;

public class GetGroupOfRecipeQueryHandler : IQueryHandler<RecipeListDto, GetGroupOfRecipeQuery>
{
    private readonly IRecipeRepository _recipeRepository;

    public GetGroupOfRecipeQueryHandler( IRecipeRepository recipeRepository )
    {
        _recipeRepository = recipeRepository;
    }

    public async Task<Result<RecipeListDto>> HandleAsync( GetGroupOfRecipeQuery query )
    {
        List<Domain.Entity.Recipe> list = await _recipeRepository.GetGroup( ( query.GroupNum - 1 ) * query.Count, query.Count );

        RecipeListDto listDto = new();
        foreach ( Domain.Entity.Recipe recipe in list )
        {
            RecipeDto recipeDto = new()
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                CookingTime = recipe.CookingTime,
                PersonNum = recipe.PersonNum,
                Image = recipe.Image,
            };

            foreach ( Ingredient ingredient in recipe.Ingredients )
            {
                recipeDto.Ingredients.Add( new()
                {
                    Id = ingredient.Id,
                    Header = ingredient.Header,
                    SubIngredients = ingredient.SubIngredients,
                } );
            }
            foreach ( RecipeStep recipeStep in recipe.Steps )
            {
                recipeDto.RecipeSteps.Add( new()
                {
                    Id = recipeStep.Id,
                    StepNum = recipeStep.StepNum,
                    Description = recipeStep.Description,
                } );
            }

            listDto.Recipes.Add( recipeDto );
        }

        return Result<RecipeListDto>.FromSuccess( listDto );
    }
}
