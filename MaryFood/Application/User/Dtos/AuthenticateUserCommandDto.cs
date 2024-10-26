namespace Application.User.Dtos;

public class AuthenticateUserCommandDto
{
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }
}
