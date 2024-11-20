namespace WebApi.Contract.Response.Recipe;

public class GetIngredientResponse
{
    public int Id { get; init; }
    public string Header { get; init; }
    public string SubIngredients { get; init; }
}
