namespace Application.UseCases.Recipe.Command.CreateRecipeCommand;

public class CreateRecipeCommand
{
    public string Name { get; init; }
    public string Description { get; init; }
    public int CookingTime { get; init; }
    public int PersonNum { get; init; }
    public string Image { get; init; }
    public DateTime CreatedDate { get; init; }

    public int UserId { get; init; }

    public List<CreateIngredientCommand> Ingredients { get; init; } = [];
    public List<CreateRecipeStepCommand> RecipeSteps { get; init; } = [];
    public List<string> Tags { get; init; } = [];
}
