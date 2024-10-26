namespace WebApi.Contract.Request;

public class LoginUserRequest
{
    public string Login { get; init; }
    public string PasswordHash { get; init; }
}
