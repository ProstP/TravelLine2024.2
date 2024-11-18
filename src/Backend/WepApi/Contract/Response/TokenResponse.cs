namespace WebApi.Contract.Response;

public class TokenResponse
{
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }
}
