using System.Security.Claims;
using Application.Result;
using Application.UseCases.Recipe.Command.CreateRecipeCommand;
using Application.UseCases.Recipe.Command.DeleteRecipeCommand;
using Application.UseCases.Recipe.Command.UpdateRecipeCommand;
using Application.UseCases.Recipe.Dtos;
using Application.UseCases.Recipe.Query.GetRecipeQuery;
using Microsoft.AspNetCore.Authorization;
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
    private readonly UpdateRecipeCommandHandler _updateRecipeCommandHandler;

    public RecipeController(
        CreateRecipeCommandHandler createRecipeCommandHandler,
        GetRecipeQueryHandler getRecipeQueryHandler,
        DeleteRecipeCommandHandler deleteRecipeCommandHandler,
        UpdateRecipeCommandHandler updateRecipeCommandHandler
    )
    {
        _createRecipeCommandHandler = createRecipeCommandHandler;
        _getRecipeQueryHandler = getRecipeQueryHandler;
        _deleteRecipeCommandHandler = deleteRecipeCommandHandler;
        _updateRecipeCommandHandler = updateRecipeCommandHandler;
    }

    [Authorize]
    [HttpPost, Route( "create" )]
    public async Task<IActionResult> Create( [FromBody] CreateRecipeRequest request )
    {
        string userLogin = User.FindFirstValue( ClaimTypes.NameIdentifier );

        CreateRecipeCommand command = new()
        {
            Name = request.Name,
            Description = request.Description,
            CookingTime = request.CookingTime,
            PersonNum = request.PersonNum,
            Image = request.Image,
            CreatedDate = DateTime.UtcNow,
            UserLogin = userLogin,
            Ingredients = request.Ingredients
                .Select( i =>
                new CreateIngredientCommand()
                {
                    Header = i.Header,
                    SubIngredients = i.SubIngredients
                } ).ToList(),
            RecipeSteps = request.RecipeSteps
                .Select( ( rs, index ) =>
                new CreateRecipeStepCommand()
                {
                    StepNum = index + 1,
                    Description = rs.Description,
                } ).ToList(),
            Tags = request.Tags
        };

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

        List<RecipeStepDto> sortedSteps = result.Value.RecipeSteps.OrderBy( rs => rs.StepNum ).ToList();

        GetRecipeResponse getRecipeResponse = new()
        {
            Id = result.Value.Id,
            Name = result.Value.Name,
            Description = result.Value.Description,
            CookingTime = result.Value.CookingTime,
            PersonNum = result.Value.PersonNum,
            Image = result.Value.Image,
            CreatedDate = result.Value.CreatedDate,
            UserId = result.Value.UserId,
            Ingredients = result.Value.Ingredients
                .Select( i =>
                new GetIngredientResponse()
                {
                    Id = i.Id,
                    Header = i.Header,
                    SubIngredients = i.SubIngredients,
                } ).ToList(),
            RecipeSteps = sortedSteps
                .Select( rs =>
                new GetRecipeStepResponse()
                {
                    Id = rs.Id,
                    Description = rs.Description,
                } ).ToList(),
            Tags = result.Value.Tags
        };

        return Ok( getRecipeResponse );
    }

    [Authorize]
    [HttpDelete, Route( "{id:int}" )]
    public async Task<IActionResult> Remove( [FromRoute] int id )
    {
        string userLogin = User.FindFirstValue( ClaimTypes.NameIdentifier );

        DeleteRecipeCommand command = new()
        {
            Id = id,
            UserLogin = userLogin,
        };

        Result result = await _deleteRecipeCommandHandler.HandleAsync( command );

        if ( !result.IsSuccess )
        {
            return BadRequest( result.Error );
        }

        return Ok();
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update( [FromBody] UpdateRecipeRequest request )
    {
        string userLogin = User.FindFirstValue( ClaimTypes.NameIdentifier );

        UpdateRecipeCommand updateRecipeCommand = new()
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            CookingTime = request.CookingTime,
            PersonNum = request.PersonNum,
            Image = request.Image,
            UserLogin = userLogin,
            Ingredients = request.Ingredients
                .Select( i =>
                new UpdateIngredientCommand()
                {
                    Id = i.Id,
                    Header = i.Header,
                    SubIngredients = i.SubIngredients
                } ).ToList(),
            RecipeSteps = request.RecipeSteps
                .Select( ( rs, index ) =>
                new UpdateRecipeStepCommand()
                {
                    Id = rs.Id,
                    StepNum = index + 1,
                    Description = rs.Description,
                } ).ToList(),
            Tags = request.Tags
        };

        Result result = await _updateRecipeCommandHandler.HandleAsync( updateRecipeCommand );

        if ( !result.IsSuccess )
        {
            return BadRequest( result.Error );
        }

        return Ok();
    }
}
