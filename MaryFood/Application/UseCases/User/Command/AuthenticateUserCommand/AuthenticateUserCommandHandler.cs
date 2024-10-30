using Application.CQRSInterfaces;
using Application.Crypt.VerifyHash;
using Application.Result;
using Application.UseCases.Token.CreateToken;
using Application.UseCases.User.Dtos;
using Domain.Repository;

namespace Application.UseCases.User.Command.AuthenticateUserCommand;

public class AuthenticateUserCommandHandler : ICommandHandler<AuthenticateUserCommandDto, AuthenticateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenCreator _tokenCreator;
    private readonly IPasswordVerifier _passwordVerifier;

    public AuthenticateUserCommandHandler( IUserRepository userRepository, ITokenCreator tokenCreator, IPasswordVerifier passwordVerifier )
    {
        _userRepository = userRepository;
        _tokenCreator = tokenCreator;
        _passwordVerifier = passwordVerifier;
    }

    public async Task<Result<AuthenticateUserCommandDto>> HandleAsync( AuthenticateUserCommand command )
    {
        Domain.Entity.User user = await _userRepository.GetByLogin( command.Login );
        if ( user == null || !_passwordVerifier.Verify( command.Password, user.PasswordHash ) )
        {
            return Result<AuthenticateUserCommandDto>.FromError( "User not found" );
        }

        AuthenticateUserCommandDto result = new()
        {
            AccessToken = _tokenCreator.GenerateAccessToken( user.Login ),
            RefreshToken = _tokenCreator.GenerateRefreshToken( user.Login, user.PasswordHash )
        };

        return Result<AuthenticateUserCommandDto>.FromSuccess( result );
    }
}
