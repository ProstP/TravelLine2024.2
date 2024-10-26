using Application.Token.DecodeToken;
using Application.Token.RefreshTokens;
using Application.Users.Command.AuthenticateUserCommand;
using Application.Users.Command.CreateUserCommand;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApi.Contract.Request;
using WebApi.Contract.Response;

namespace WebApi.Controller
{
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
        public IActionResult Register( [FromBody] RegisterUserRequest request )
        {
            var command = new CreateUserCommand()
            {
                Login = request.Login,
                Password = request.PasswordHash,
            };
            bool isSeccess = _createUserCommandHandler.Handle( command );

            if ( !isSeccess )
            {
                return BadRequest();
            }

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost, Route( "login" )]
        public async Task<IActionResult> Login( [FromBody] LoginUserRequest request )
        {
            var command = new AuthenticateUserCommand()
            {
                Login = request.Login,
                Password = request.PasswordHash
            };

            var tokens = await _authenticateUserCommandHandler.Handle( command );

            if ( tokens == null )
            {
                return BadRequest();
            }
            var result = new LoginUserResponse()
            {
                AccessToken = tokens.AccessToken,
                RefreshToken = tokens.RefreshToken
            };

            return Ok( result );
        }

        [AllowAnonymous]
        [HttpPost, Route( "refresh" )]
        public async Task<IActionResult> RefreshToken( [FromBody] RefreshTokenRequest request )
        {
            var command = new RefreshTokenCommand()
            {
                Token = request.RefreshToken,
            };
            var tokens = await _refreshTokenCommandHandler.Refresh( command );

            if ( tokens == null )
            {
                return BadRequest();
            }

            return Ok( tokens );
        }
    }
}
