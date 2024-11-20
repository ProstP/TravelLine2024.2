using Application.UseCases.Token.Dtos;

namespace Application.UseCases.Token.DecodeToken;
public interface ITokenDecoder
{
    DecodeTokenDto Decode( string token );
}
