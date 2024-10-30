namespace Application.UseCases.Token.Dtos;

public class DecodeTokenDto
{
    public string Login { get; init; }
    public string PasswordHash { get; init; }
}
