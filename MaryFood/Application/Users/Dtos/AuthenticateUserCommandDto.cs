namespace Application.Users.Dtos;

public class AuthenticateUserCommandDto
{
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }
}
