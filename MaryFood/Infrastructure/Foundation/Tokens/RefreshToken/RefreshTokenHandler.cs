using Application.Token.CreateToken;
using Application.Token.DecodeToken;
using Application.Token.Dtos;
using Domain.Entity;
using Domain.Repository;

namespace Application.Token.RefreshTokens;

public class RefreshTokenHandler
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenDecoder _tokenDecoder;
    private readonly ITokenCreator _tokenCreator;

    public RefreshTokenHandler( IUserRepository userRepository, ITokenDecoder tokenDecoder, ITokenCreator tokenCreator )
    {
        _userRepository = userRepository;
        _tokenDecoder = tokenDecoder;
        _tokenCreator = tokenCreator;
    }

    public async Task<RefreshTokenDto> Refresh( RefreshTokenCommand token )
    {
        DecodeTokenDto decodeTokenDto = _tokenDecoder.Decode( token.Token );

        User user = await _userRepository.GetByLogin( decodeTokenDto.Login );
        if ( user == null || user.PasswordHash != decodeTokenDto.PasswordHash )
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