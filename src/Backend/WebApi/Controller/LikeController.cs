using System.Security.Claims;
using Application.Result;
using Application.UseCases.Like.Command.CreateLike;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contract.Request.Like;

namespace WebApi.Controller;

[ApiController]
[Route( "api/like" )]
public class LikeController : ControllerBase
{
    private readonly CreateLikeCommandHanlder _createLikeCommandHanlder;

    public LikeController( CreateLikeCommandHanlder createLikeCommandHanlder )
    {
        _createLikeCommandHanlder = createLikeCommandHanlder;
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
}
