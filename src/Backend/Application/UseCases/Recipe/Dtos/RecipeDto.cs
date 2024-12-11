namespace Application.UseCases.Recipe.Dtos;

public class RecipeDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public int CookingTime { get; init; }
    public int PersonNum { get; init; }
    public string Image { get; init; }
    public DateTime CreatedDate { get; init; }

    public int UserId { get; init; }

    public List<IngredientDto> Ingredients { get; init; } = [];
    public List<RecipeStepDto> RecipeSteps { get; init; } = [];
    public List<string> Tags { get; init; } = [];
}
