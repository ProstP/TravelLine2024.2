using System.Security.Claims;
using Application.Result;
using Application.UseCases.Like.Command.CreateLike;
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

    public LikeController( CreateLikeCommandHanlder createLikeCommandHanlder, IsUserSetLikeQueryHandler isUserSetLikeQueryHandler )
    {
        _createLikeCommandHanlder = createLikeCommandHanlder;
        _isUserSetLikeQueryHandler = isUserSetLikeQueryHandler;
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
    [HttpPost, Route( "user" )]
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
