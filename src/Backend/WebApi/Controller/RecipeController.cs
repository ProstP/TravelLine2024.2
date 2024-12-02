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
            UserId = 14,
            Ingredients = request.Ingredients
                .Select( i =>
                new CreateIngredientCommand()
                {
                    Header = i.Header,
                    SubIngredients = i.SubIngredients
                } ).ToList(),
            RecipeSteps = request.RecipeSteps
                .Select( rs =>
                new CreateRecipeStepCommand()
                {
                    StepNum = rs.StepNum,
                    Description = rs.Description,
                } ).ToList()
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

        GetRecipeResponse getRecipeResponse = new()
        {
            Id = result.Value.Id,
            Name = result.Value.Name,
            Description = result.Value.Description,
            CookingTime = result.Value.CookingTime,
            PersonNum = result.Value.PersonNum,
            Image = result.Value.Image,
            UserId = result.Value.UserId,
            Ingredients = result.Value.Ingredients
                .Select( i =>
                new GetIngredientResponse()
                {
                    Id = i.Id,
                    Header = i.Header,
                    SubIngredients = i.SubIngredients,
                } ).ToList(),
            RecipeSteps = result.Value.RecipeSteps
                .Select( rs =>
                new GetRecipeStepResponse()
                {
                    Id = rs.Id,
                    StepNum = rs.StepNum,
                    Description = rs.Description,
                } ).ToList()
        };

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

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update( [FromBody] UpdateRecipeRequest request )
    {
        UpdateRecipeCommand updateRecipeCommand = new()
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            CookingTime = request.CookingTime,
            PersonNum = request.PersonNum,
            Image = request.Image,
            Ingredients = request.Ingredients
                .Select( i =>
                new UpdateIngredientCommand()
                {
                    Header = i.Header,
                    SubIngredients = i.SubIngredients
                } ).ToList(),
            RecipeSteps = request.RecipeSteps
                .Select( rs =>
                new UpdateRecipeStepCommand()
                {
                    StepNum = rs.StepNum,
                    Description = rs.Description,
                } ).ToList()
        };

        Result result = await _updateRecipeCommandHandler.HandleAsync( updateRecipeCommand );

        if ( !result.IsSuccess )
        {
            return BadRequest( result.Error );
        }

        return Ok();
    }
}
