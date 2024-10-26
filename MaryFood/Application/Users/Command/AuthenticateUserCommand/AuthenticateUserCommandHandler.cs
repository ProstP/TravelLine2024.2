using Application.Crypt.VerifyHash;
using Application.Token.CreateToken;
using Application.Users.Dtos;
using Domain.Entity;
using Domain.Repository;

namespace Application.Users.Command.AuthenticateUserCommand;

public class AuthenticateUserCommandHandler
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

    public async Task<AuthenticateUserCommandDto> Handle( AuthenticateUserCommand command )
    {
        User user = await _userRepository.GetByLogin( command.Login );
        if ( user == null || !_passwordVerifier.Verify( command.Password, user.PasswordHash ) )
        {
            return null;
        }

        AuthenticateUserCommandDto result = new()
        {
            AccessToken = _tokenCreator.GenerateAccessToken( user.Login ),
            RefreshToken = _tokenCreator.GenerateRefreshToken( user.Login, user.PasswordHash )
        };

        return result;
    }
}
