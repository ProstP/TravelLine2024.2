namespace WebApi.Contract.Response.User;

public class UserProfileResponse
{
    public string Name { get; init; }
    public string Login { get; init; }
    public string About { get; init; }
    public int RecipeCount { get; init; }
    public int LikeCount { get; init; }
    public int FavouriteCount { get; init; }
}
