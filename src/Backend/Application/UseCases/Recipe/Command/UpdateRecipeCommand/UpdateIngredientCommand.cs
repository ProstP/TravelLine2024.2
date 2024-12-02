namespace Application.UseCases.Recipe.Command.UpdateRecipeCommand;

public class UpdateIngredientCommand
{
    public int Id { get; init; }
    public string Header { get; init; }
    public string SubIngredients { get; init; }
}
