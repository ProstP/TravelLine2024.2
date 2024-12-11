namespace WebApi.Contract.Response.User;

public class UpdateUserResponse
{
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }
}
