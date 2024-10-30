using Application.CQRSInterfaces;
using Application.Result;
using Application.UseCases.Token.CreateToken;
using Application.UseCases.Token.DecodeToken;
using Application.UseCases.Token.Dtos;
using Domain.Repository;

namespace Application.UseCases.Token.RefreshTokens;

public class RefreshTokenHandler : ICommandHandler<RefreshTokenDto, RefreshTokenCommand>
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

    public async Task<Result<RefreshTokenDto>> HandleAsync( RefreshTokenCommand token )
    {
        DecodeTokenDto decodeTokenDto = _tokenDecoder.Decode( token.Token );
        if ( decodeTokenDto == null )
        {
            return Result<RefreshTokenDto>.FromError( "Token not available" );
        }

        Domain.Entity.User user = await _userRepository.GetByLogin( decodeTokenDto.Login );
        if ( user == null )
        {
            return Result<RefreshTokenDto>.FromError( "User not found" );
        }

        RefreshTokenDto refreshTokenDto = new()
        {
            AccessToken = _tokenCreator.GenerateAccessToken( user.Login ),
            RefreshToken = _tokenCreator.GenerateRefreshToken( user.Login ),
        };

        return Result<RefreshTokenDto>.FromSuccess( refreshTokenDto );
    }
}