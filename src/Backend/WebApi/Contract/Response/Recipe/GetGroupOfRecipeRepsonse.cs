namespace WebApi.Contract.Response.Recipe;

public class GetGroupOfRecipeRepsonse
{
    public List<GetRecipeResponse> Recipes { get; init; } = [];
}
