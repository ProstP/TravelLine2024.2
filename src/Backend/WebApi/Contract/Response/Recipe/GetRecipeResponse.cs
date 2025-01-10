namespace WebApi.Contract.Response.Recipe;

public class GetRecipeResponse
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public int CookingTime { get; init; }
    public int PersonNum { get; init; }
    public string Image { get; init; }
    public DateTime CreatedDate { get; init; }

    public int UserId;

    public List<GetIngredientResponse> Ingredients { get; init; } = [];
    public List<GetRecipeStepResponse> RecipeSteps { get; init; } = [];
    public List<string> Tags { get; init; } = [];
    public int LikeCount { get; init; }
}
