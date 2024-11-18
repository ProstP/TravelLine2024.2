using Application.UseCases.Recipe.Command.CreateRecipeCommand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contract.Request.Recipe;

namespace WebApi.Controller;

[ApiController]
[Route( "api/recipe" )]
public class RecipeController : ControllerBase
{
    private readonly CreateRecipeCommandHandler _createRecipeCommandHandler;

    public RecipeController( CreateRecipeCommandHandler createRecipeCommandHandler )
    {
        _createRecipeCommandHandler = createRecipeCommandHandler;
    }

    [AllowAnonymous]
    [HttpPost, Route( "create" )]
    public async Task<IActionResult> Create( [FromBody] CreateRecipeRequest request )
    {
        CreateRecipeCommand command = new()
        {
            Name = request.Name,
            Description = request.Description,
            CookingTime = request.CookingTime,
            PersonNum = request.PersonNum,
            Image = request.Image,
            UserId = 14
        };

        foreach ( CreateIngredientsRequest ingredient in request.Ingredients )
        {
            command.Ingredients.Add( new CreateIngredientCommand()
            {
                Header = ingredient.Header,
                SubIngredients = ingredient.SubIngredients,
            } );
        }

        foreach ( CreateRecipeStepRequest recipeStep in request.RecipeSteps )
        {
            command.RecipeSteps.Add( new CreateRecipeStepCommand()
            {
                StepNum = recipeStep.StepNum,
                Description = recipeStep.Description,
            } );
        }

        Application.Result.Result result = await _createRecipeCommandHandler.HandleAsync( command );

        if ( !result.IsSuccess )
        {
            return BadRequest( result.Error );
        }

        return Ok();
    }
}
