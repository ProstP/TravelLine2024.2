namespace Application.UseCases.User.Dtos;

public class UpdateUserDto
{
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }
}
