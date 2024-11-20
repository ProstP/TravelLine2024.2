namespace WebApi.Contract.Response;

public class UpdateUserResponse
{
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }
}
