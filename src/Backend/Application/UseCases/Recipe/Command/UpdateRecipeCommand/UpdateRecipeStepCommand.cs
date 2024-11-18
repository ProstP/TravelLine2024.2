namespace Application.UseCases.Recipe.Command.UpdateRecipeCommand;

public class UpdateRecipeStepCommand
{
    public int Id { get; init; }
    public int StepNum { get; init; }
    public string Description { get; init; }
}
