namespace Application.UseCases.User.Dtos;

public class AuthenticateUserCommandDto
{
    public string UserName { get; init; }
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }
}
