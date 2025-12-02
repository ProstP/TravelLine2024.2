using System.Security.Claims;
using Application.Result;
using Application.UseCases.Favourite.Command.CreateFavourite;
using Application.UseCases.Favourite.Query.GetFavouriteCount;
using Application.UseCases.Favourite.Query.IdUserSetFavourite;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contract.Request.Favourite;
using WebApi.Contract.Response.Favourite;
using WebApi.Contract.Response.Like;

namespace WebApi.Controller;

[ApiController]
[Route( "api/favourite" )]
public class FavouriteController : ControllerBase
{
    private readonly CreateFavouriteCommandHandler _createFavouriteCommandHandler;
    private readonly IsUserSetFavouriteQueryHandler _isUserSetFavouriteQueryHandler;
    private readonly GetFavouriteCountQueryHandler _getFavouriteCountQueryHandler;

    public FavouriteController(
            CreateFavouriteCommandHandler createFavouriteCommandHandler,
            IsUserSetFavouriteQueryHandler isUserSetFavouriteQueryHandler,
            GetFavouriteCountQueryHandler getFavouriteCountQueryHandler
        )
    {
        _createFavouriteCommandHandler = createFavouriteCommandHandler;
        _isUserSetFavouriteQueryHandler = isUserSetFavouriteQueryHandler;
        _getFavouriteCountQueryHandler = getFavouriteCountQueryHandler;
    }

    [HttpPost, Route( "recipe" )]
    public async Task<ActionResult<GetFavouriteCountByRecipeResponse>> GetFavouriteCountByRecipe( [FromBody] GetFavouriteCountByRecipeRequest request )
    {
        GetFavouriteCountQuery query = new()
        {
            Id = request.RecipeId,
            FromRecipe = true
        };

        Result<GetFavouriteCountResult> result = await _getFavouriteCountQueryHandler.HandleAsync( query );

        if ( !result.IsSuccess )
        {
            return BadRequest( result.Error );
        }

        GetFavouriteCountByRecipeResponse response = new()
        {
            Count = result.Value.Count,
        };

        return Ok( response );
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> SetFavourite( [FromBody] SetFavouriteRequest request )
    {
        string userLogin = User.FindFirstValue( ClaimTypes.NameIdentifier );

        CreateFavouriteCommand command = new()
        {
            UserLogin = userLogin,
            RecipeId = request.RecipeId,
        };

        Result result = await _createFavouriteCommandHandler.HandleAsync( command );

        if ( !result.IsSuccess )
        {
            return BadRequest( result.Error );
        }

        return Ok();
    }

    [Authorize]
    [HttpPost, Route( "is-user" )]
    public async Task<ActionResult<IsUserSetLikeResponse>> IsUserSetFavourite( [FromBody] IsUserSetFavouriteRequest request )
    {
        string userLogin = User.FindFirstValue( ClaimTypes.NameIdentifier );

        IsUserSetFavouriteQuery query = new()
        {
            UserLogin = userLogin,
            RecipeId = request.RecipeId
        };

        Result<IsUserSetFavouriteResult> result = await _isUserSetFavouriteQueryHandler.HandleAsync( query );

        if ( !result.IsSuccess )
        {
            return BadRequest( result.Error );
        }

        IsUserSetFavouriteResponse response = new()
        {
            IsSet = result.Value.IsSet,
        };

        return Ok( response );
    }
}
