namespace WebApi.Contract.Response.User;

public class LoginUserResponse
{
    public string Username { get; init; }
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }
}
