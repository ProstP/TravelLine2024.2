namespace WebApi.Contract.Request;

public class RegisterUserRequest
{
    public string Login { get; init; }
    public string PasswordHash { get; init; }
}
