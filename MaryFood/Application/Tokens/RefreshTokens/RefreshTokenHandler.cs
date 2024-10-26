using Application.Tokens.CreateToken;
using Application.Tokens.DecodeToken;
using Application.Tokens.Dtos;
using Domain.Repository;

namespace Application.Tokens.RefreshTokens
{
    public class RefreshTokenHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly RefreshTokenDecoder _refreshTokenDecoder;
        private readonly TokenCreator _tokenCreator;

        public RefreshTokenHandler( IUserRepository userRepository, RefreshTokenDecoder refreshTokenDecoder, TokenCreator tokenCreator )
        {
            _userRepository = userRepository;
            _refreshTokenDecoder = refreshTokenDecoder;
            _tokenCreator = tokenCreator;
        }

        public async Task<RefreshTokenDto> Refresh( RefreshTokenCommand token )
        {
            var dto = _refreshTokenDecoder.Decode( token.Token );

            var user = await _userRepository.GetByLogin( dto.Login );
            if ( user == null || user.PasswordHash != dto.PasswordHash )
            {
                return null;
            }

            var result = new RefreshTokenDto()
            {
                AccessToken = _tokenCreator.GenerateAccessToken( user.Login ),
                RefreshToken = _tokenCreator.GenerateRefreshToken( user.Login, user.PasswordHash ),
            };

            return result;
        }
    }
}