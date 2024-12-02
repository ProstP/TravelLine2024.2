using Application.CQRSInterfaces;
using Application.Result;
using Application.UseCases.Token.CreateToken;
using Application.UseCases.Token.DecodeToken;
using Application.UseCases.Token.Dtos;
using Application.UseCases.User.Dtos;
using Domain.Repository;

namespace Application.UseCases.User.Command.AuthenticateByTokenCommand;

public class AuthenticateByTokenCommandHandler : ICommandHandler<AuthenticateUserCommandDto, AuthenticateByTokenCommand>
{
    private readonly ITokenDecoder _tokenDecoder;
    private readonly ITokenCreator _tokenCreator;
    private readonly IUserRepository _userRepository;

    public AuthenticateByTokenCommandHandler( ITokenCreator tokenCreator, ITokenDecoder tokenDecoder, IUserRepository userRepository )
    {
        _tokenDecoder = tokenDecoder;
        _tokenCreator = tokenCreator;
        _userRepository = userRepository;
    }

    public async Task<Result<AuthenticateUserCommandDto>> HandleAsync( AuthenticateByTokenCommand command )
    {
        DecodeTokenDto decodeTokenDto = _tokenDecoder.Decode( command.Token );

        Domain.Entity.User user = await _userRepository.GetByLogin( decodeTokenDto.Login );

        if ( user == null )
        {
            return Result<AuthenticateUserCommandDto>.FromError( "Unknown user" );
        }

        AuthenticateUserCommandDto authenticateUserCommandDto = new()
        {
            UserName = user.Name,
            AccessToken = _tokenCreator.GenerateAccessToken( user.Login ),
            RefreshToken = _tokenCreator.GenerateRefreshToken( user.Login ),
        };

        return Result<AuthenticateUserCommandDto>.FromSuccess( authenticateUserCommandDto );
    }
}
