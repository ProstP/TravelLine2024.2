namespace Application.UseCases.Token.CreateToken;
public interface ITokenCreator
{
    string GenerateAccessToken( string login );
    string GenerateRefreshToken( string login );
}
