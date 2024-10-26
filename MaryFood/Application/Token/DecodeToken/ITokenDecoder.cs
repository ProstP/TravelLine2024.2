using Application.Token.Dtos;

namespace Application.Token.DecodeToken;
public interface ITokenDecoder
{
    DecodeTokenDto Decode( string token );
}
