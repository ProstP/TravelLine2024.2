namespace WebApi.Contract.Response.Recipe;

public class GetRecipeStepResponse
{
    public int Id { get; init; }
    public int StepNum { get; init; }
    public string Description { get; init; }
}
