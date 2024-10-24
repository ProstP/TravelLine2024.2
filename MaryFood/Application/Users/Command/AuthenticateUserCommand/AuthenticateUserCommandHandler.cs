using Application.Tokens.CreateToken;
using Application.Users.Dtos;
using Domain.Repository;

namespace Application.Users.Command.AuthenticateUserCommand
{
    public class AuthenticateUserCommandHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenCreator _tokenCreator;

        public AuthenticateUserCommandHandler( IUserRepository userRepository, TokenCreator tokenCreator )
        {
            _userRepository = userRepository;
            _tokenCreator = tokenCreator;
        }

        public async Task<AuthenticateUserCommandDto> Handle( AuthenticateUserCommand command )
        {
            var user = await _userRepository.GetByLodin( command.Login );
            if ( user == null || user.PasswordHash != command.PasswordHash )
            {
                return null;
            }

            var result = new AuthenticateUserCommandDto()
            {
                AccessToken = _tokenCreator.GenerateAccessToken( user.Login ),
                RefreshToken = _tokenCreator.GenerateRefreshToken( user.Login, user.PasswordHash )
            };

            return result;
        }
    }
}
