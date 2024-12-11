namespace WebApi.Contract.Response.User;

public class RefreshTokenResponse
{
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }
}
