using Application.Result;
using Application.Token.Dtos;
using Application.Token.RefreshTokens;
using Application.User.Command.AuthenticateUserCommand;
using Application.User.Command.CreateUserCommand;
using Application.User.Dtos;
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

    public UserController(
        CreateUserCommandHandler createUserCommandHandler,
        AuthenticateUserCommandHandler authenticateUserCommandHandler,
        RefreshTokenHandler refreshTokenHandler
    )
    {
        _createUserCommandHandler = createUserCommandHandler;
        _authenticateUserCommandHandler = authenticateUserCommandHandler;
        _refreshTokenCommandHandler = refreshTokenHandler;
    }

    [Authorize]
    [HttpGet, Route( "{id:int}" )]
    public IActionResult Get( [FromRoute] int id )
    {
        return Ok( id );
    }

    [AllowAnonymous]
    [HttpPost, Route( "register" )]
    public async Task<IActionResult> Register( [FromBody] RegisterUserRequest request )
    {
        CreateUserCommand command = new()
        {
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
    public async Task<IActionResult> Login( [FromBody] LoginUserRequest request )
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
        TokenResponse tokenResponse = new()
        {
            AccessToken = result.Value.AccessToken,
            RefreshToken = result.Value.RefreshToken
        };

        return Ok( tokenResponse );
    }

    [AllowAnonymous]
    [HttpPost, Route( "refresh" )]
    public async Task<IActionResult> RefreshToken( [FromBody] RefreshTokenRequest request )
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
        TokenResponse tokenResponse = new()
        {
            AccessToken = result.Value.AccessToken,
            RefreshToken = result.Value.RefreshToken
        };

        return Ok( tokenResponse );
    }
}
