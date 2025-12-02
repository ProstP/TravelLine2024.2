using System.Security.Claims;
using Application.Result;
using Application.UseCases.Like.Command.CreateLike;
using Application.UseCases.Like.Query.GetLikeCount;
using Application.UseCases.Like.Query.IsUserSetLike;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contract.Request.Like;
using WebApi.Contract.Response.Like;

namespace WebApi.Controller;

[ApiController]
[Route( "api/like" )]
public class LikeController : ControllerBase
{
    private readonly CreateLikeCommandHanlder _createLikeCommandHanlder;
    private readonly IsUserSetLikeQueryHandler _isUserSetLikeQueryHandler;
    private readonly GetLikeCountQueryHandler _getLikeCountQueryHandler;

    public LikeController(
        CreateLikeCommandHanlder createLikeCommandHanlder,
        IsUserSetLikeQueryHandler isUserSetLikeQueryHandler,
        GetLikeCountQueryHandler getLikeCountQueryHandler )
    {
        _createLikeCommandHanlder = createLikeCommandHanlder;
        _isUserSetLikeQueryHandler = isUserSetLikeQueryHandler;
        _getLikeCountQueryHandler = getLikeCountQueryHandler;
    }

    [HttpPost, Route( "recipe" )]
    public async Task<ActionResult<GetLikeCountByRecipeResponse>> GetLikeCountByRecipe( [FromBody] GetLikeCountByRecipeRequest request )
    {
        GetLikeCountQuery query = new()
        {
            Id = request.RecipeId,
            FromRecipe = true
        };

        Result<GetLikeCountResult> result = await _getLikeCountQueryHandler.HandleAsync( query );

        if ( !result.IsSuccess )
        {
            return BadRequest( result.Error );
        }

        GetLikeCountByRecipeResponse response = new()
        {
            Count = result.Value.Count,
        };

        return Ok( response );
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> SetLike( [FromBody] SetLikeRequest request )
    {
        string userLogin = User.FindFirstValue( ClaimTypes.NameIdentifier );

        CreateLikeCommand createLikeCommand = new()
        {
            UserLogin = userLogin,
            RecipeId = request.RecipeId,
        };

        Result result = await _createLikeCommandHanlder.HandleAsync( createLikeCommand );

        if ( !result.IsSuccess )
        {
            return BadRequest( result.Error );
        }

        return Ok();
    }

    [Authorize]
    [HttpPost, Route( "is-user" )]
    public async Task<ActionResult<IsUserSetLikeResponse>> IsUserSetLike( [FromBody] IsUserSetLikeRequest request )
    {
        string userLogin = User.FindFirstValue( ClaimTypes.NameIdentifier );

        IsUserSetLikeQuery query = new()
        {
            UserLogin = userLogin,
            RecipeId = request.RecipeId
        };

        Result<IsUserSetLikeQueryResult> result = await _isUserSetLikeQueryHandler.HandleAsync( query );

        if ( !result.IsSuccess )
        {
            return BadRequest( result.Error );
        }

        IsUserSetLikeResponse response = new()
        {
            IsSet = result.Value.IsSet,
        };

        return Ok( response );
    }
}
