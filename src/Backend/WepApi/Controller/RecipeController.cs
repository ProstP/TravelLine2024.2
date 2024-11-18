using Application.Result;
using Application.UseCases.Recipe.Command.CreateRecipeCommand;
using Application.UseCases.Recipe.Command.DeleteRecipeCommand;
using Application.UseCases.Recipe.Dtos;
using Application.UseCases.Recipe.Query.GetRecipeQuery;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contract.Request.Recipe;
using WebApi.Contract.Response.Recipe;

namespace WebApi.Controller;

[ApiController]
[Route( "api/recipe" )]
public class RecipeController : ControllerBase
{
    private readonly CreateRecipeCommandHandler _createRecipeCommandHandler;
    private readonly GetRecipeQueryHandler _getRecipeQueryHandler;
    private readonly DeleteRecipeCommandHandler _deleteRecipeCommandHandler;

    public RecipeController(
        CreateRecipeCommandHandler createRecipeCommandHandler,
        GetRecipeQueryHandler getRecipeQueryHandler,
        DeleteRecipeCommandHandler deleteRecipeCommandHandler
    )
    {
        _createRecipeCommandHandler = createRecipeCommandHandler;
        _getRecipeQueryHandler = getRecipeQueryHandler;
        _deleteRecipeCommandHandler = deleteRecipeCommandHandler;
    }

    //[Authorize]
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

        Result result = await _createRecipeCommandHandler.HandleAsync( command );

        if ( !result.IsSuccess )
        {
            return BadRequest( result.Error );
        }

        return Ok();
    }

    [HttpGet, Route( "{id:int}" )]
    public async Task<ActionResult<GetRecipeResponse>> Get( [FromRoute] int id )
    {
        GetRecipeQuery query = new()
        {
            RecipeId = id
        };

        Result<RecipeDto> result = await _getRecipeQueryHandler.HandleAsync( query );

        if ( !result.IsSuccess )
        {
            return BadRequest( result.Error );
        }

        GetRecipeResponse getRecipeResponse = new()
        {
            Id = result.Value.Id,
            Name = result.Value.Name,
            Description = result.Value.Description,
            CookingTime = result.Value.CookingTime,
            PersonNum = result.Value.PersonNum,
            Image = result.Value.Image,
            UserId = result.Value.UserId,
        };

        foreach ( IngredientDto ingredient in result.Value.Ingredients )
        {
            getRecipeResponse.Ingredients.Add( new GetIngredientResponse()
            {
                Id = ingredient.Id,
                Header = ingredient.Header,
                SubIngredients = ingredient.SubIngredients,
            } );
        }

        foreach ( RecipeStepDto recipeStep in result.Value.RecipeSteps )
        {
            getRecipeResponse.RecipeSteps.Add( new GetRecipeStepResponse()
            {
                Id = recipeStep.Id,
                StepNum = recipeStep.StepNum,
                Description = recipeStep.Description,
            } );
        }

        return Ok( getRecipeResponse );
    }

    //[Authorize]
    [HttpDelete]
    public async Task<IActionResult> Remove( [FromBody] DeleteRecipeRequest request )
    {
        DeleteRecipeCommand command = new()
        {
            Id = request.Id,
        };

        Result result = await _deleteRecipeCommandHandler.HandleAsync( command );

        return Ok();
    }
}
