using System.Security.Claims;
using Application.Result;
using Application.UseCases.Token.Dtos;
using Application.UseCases.Token.RefreshTokens;
using Application.UseCases.User.Command.AuthenticateByTokenCommand;
using Application.UseCases.User.Command.AuthenticateUserCommand;
using Application.UseCases.User.Command.CreateUserCommand;
using Application.UseCases.User.Command.UpdateUserCommand;
using Application.UseCases.User.Dtos;
using Application.UseCases.User.Query.GetUserQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contract.Request.User;
using WebApi.Contract.Response.User;

namespace WebApi.Controller;

[ApiController]
[Route( "api/user" )]
public class UserController : ControllerBase
{
    private readonly CreateUserCommandHandler _createUserCommandHandler;
    private readonly AuthenticateUserCommandHandler _authenticateUserCommandHandler;
    private readonly UpdateUserCommandHandler _updateUserCommandHandler;
    private readonly RefreshTokenHandler _refreshTokenCommandHandler;
    private readonly GetUserQueryHandler _getUserQueryHandler;
    private readonly AuthenticateByTokenCommandHandler _authenticateByTokenCommandHandler;

    public UserController(
        CreateUserCommandHandler createUserCommandHandler,
        AuthenticateUserCommandHandler authenticateUserCommandHandler,
        UpdateUserCommandHandler updateUserCommandHandler,
        RefreshTokenHandler refreshTokenHandler,
        GetUserQueryHandler getUserQueryHandler,
        AuthenticateByTokenCommandHandler authenticateByTokenCommandHandler
    )
    {
        _createUserCommandHandler = createUserCommandHandler;
        _authenticateUserCommandHandler = authenticateUserCommandHandler;
        _updateUserCommandHandler = updateUserCommandHandler;
        _refreshTokenCommandHandler = refreshTokenHandler;
        _getUserQueryHandler = getUserQueryHandler;
        _authenticateByTokenCommandHandler = authenticateByTokenCommandHandler;
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

    [Authorize]
    [HttpPost, Route( "login-by-token" )]
    public async Task<ActionResult> LoginByToken()
    {
        string authStr = Request.Headers.Authorization;
        string token = authStr.Substring( 7 );

        AuthenticateByTokenCommand command = new()
        {
            Token = token,
        };

        Result<AuthenticateUserCommandDto> result = await _authenticateByTokenCommandHandler.HandleAsync( command );

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

    [Authorize]
    [HttpPut, Route( "update-profile" )]
    public async Task<ActionResult<UpdateUserResponse>> Update( [FromBody] UpdateUserRequest request )
    {
        string userLogin = User.FindFirstValue( ClaimTypes.NameIdentifier );

        if ( userLogin == null )
        {
            return BadRequest();
        }

        UpdateUserCommand updateUserCommand = new()
        {
            OldLogin = userLogin,
            Login = request.Login,
            Name = request.Name,
            Password = request.Password,
            About = request.About,
        };

        Result<UpdateUserDto> result = await _updateUserCommandHandler.HandleAsync( updateUserCommand );
        if ( !result.IsSuccess )
        {
            return BadRequest( result.Error );
        }

        UpdateUserResponse userProfileResponse = new()
        {
            AccessToken = result.Value.AccessToken,
            RefreshToken = result.Value.RefreshToken,
        };

        return Ok( userProfileResponse );
    }
}
