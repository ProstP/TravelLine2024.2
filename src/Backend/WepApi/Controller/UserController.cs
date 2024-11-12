using System.Security.Claims;
using Application.Result;
using Application.UseCases.Token.Dtos;
using Application.UseCases.Token.RefreshTokens;
using Application.UseCases.User.Command.AuthenticateUserCommand;
using Application.UseCases.User.Command.CreateUserCommand;
using Application.UseCases.User.Dtos;
using Application.UseCases.User.Query.GetUserQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contract.Request;
using WebApi.Contract.Response;

namespace WebApi.Controller;

[ApiController]
[Route( "api/user" )]
public class UserController : ControllerBase
{
    private readonly CreateUserCommandHandler _createUserCommandHandler;
    private readonly AuthenticateUserCommandHandler _authenticateUserCommandHandler;
    private readonly RefreshTokenHandler _refreshTokenCommandHandler;
    private readonly GetUserQueryHandler _getUserQueryHandler;

    public UserController(
        CreateUserCommandHandler createUserCommandHandler,
        AuthenticateUserCommandHandler authenticateUserCommandHandler,
        RefreshTokenHandler refreshTokenHandler
        , GetUserQueryHandler getUserQueryHandler
    )
    {
        _createUserCommandHandler = createUserCommandHandler;
        _authenticateUserCommandHandler = authenticateUserCommandHandler;
        _refreshTokenCommandHandler = refreshTokenHandler;
        _getUserQueryHandler = getUserQueryHandler;
    }

    [AllowAnonymous]
    [HttpPost, Route( "register" )]
    public async Task<IActionResult> Register( [FromBody] RegisterUserRequest request )
    {
        CreateUserCommand command = new()
        {
            Name = request.Name,
            Login = request.Login,
            Password = request.Password,
        };
        Result result = await _createUserCommandHandler.HandleAsync( command );

        if ( !result.IsSuccess )
        {
            return BadRequest( result.Error );
        }
        return Ok();
    }

    [AllowAnonymous]
    [HttpPost, Route( "login" )]
    public async Task<ActionResult<LoginUserResponse>> Login( [FromBody] LoginUserRequest request )
    {
        AuthenticateUserCommand command = new()
        {
            Login = request.Login,
            Password = request.Password
        };

        Result<AuthenticateUserCommandDto> result = await _authenticateUserCommandHandler.HandleAsync( command );

        if ( !result.IsSuccess )
        {
            return BadRequest( result.Error );
        }
        LoginUserResponse loginUserResponse = new()
        {
            Username = result.Value.UserName,
            AccessToken = result.Value.AccessToken,
            RefreshToken = result.Value.RefreshToken
        };

        return Ok( loginUserResponse );
    }

    [AllowAnonymous]
    [HttpPost, Route( "refresh-token" )]
    public async Task<ActionResult<RefreshTokenResponse>> RefreshToken( [FromBody] RefreshTokenRequest request )
    {
        RefreshTokenCommand command = new()
        {
            Token = request.RefreshToken,
        };
        Result<RefreshTokenDto> result = await _refreshTokenCommandHandler.HandleAsync( command );

        if ( !result.IsSuccess )
        {
            return BadRequest( result.Error );
        }
        RefreshTokenResponse refreshTokenResponse = new()
        {
            AccessToken = result.Value.AccessToken,
            RefreshToken = result.Value.RefreshToken
        };

        return Ok( refreshTokenResponse );
    }

    [Authorize]
    [HttpGet, Route( "profile" )]
    public async Task<ActionResult<UserProfileResponse>> Profile()
    {
        string userLogin = User.FindFirstValue( ClaimTypes.NameIdentifier );

        if ( userLogin == null )
        {
            return BadRequest();
        }

        GetUserQuery query = new()
        {
            Login = userLogin,
        };

        Result<GetUserQueryDto> result = await _getUserQueryHandler.HandleAsync( query );
        if ( !result.IsSuccess )
        {
            return BadRequest( result.Error );
        }

        UserProfileResponse userProfileResponse = new()
        {
            Name = result.Value.Name,
            Login = result.Value.Login,
            About = result.Value.About,
        };

        return Ok( userProfileResponse );
    }
}
