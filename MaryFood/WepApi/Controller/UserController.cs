using Application.Result;
using Application.UseCases.Token.Dtos;
using Application.UseCases.Token.RefreshTokens;
using Application.UseCases.User.Command.AuthenticateUserCommand;
using Application.UseCases.User.Command.CreateUserCommand;
using Application.UseCases.User.Dtos;
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
    public async Task<ActionResult<TokenResponse>> Login( [FromBody] LoginUserRequest request )
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
    [HttpPost, Route( "refresh-token" )]
    public async Task<ActionResult<TokenResponse>> RefreshToken( [FromBody] RefreshTokenRequest request )
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
