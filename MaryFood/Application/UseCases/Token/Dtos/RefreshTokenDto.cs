namespace Application.UseCases.Token.Dtos;

public class RefreshTokenDto
{
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }
}
