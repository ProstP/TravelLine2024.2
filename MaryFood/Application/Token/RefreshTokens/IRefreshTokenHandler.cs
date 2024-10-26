using Application.Token.Dtos;

namespace Application.Token.RefreshTokens;
public interface IRefreshTokenHandler
{
    RefreshTokenDto Refresh( RefreshTokenCommand command );
}
