namespace WebApi.Contract.Response;

public class LoginUserResponse
{
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }
}
