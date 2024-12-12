namespace Application.UseCases.Recipe.Query.GetRecipeListQuery;

public class GetRecipeListQuery
{
    public int GroupNum { get; init; }
    public int Count { get; init; }
    public string OrderType { get; init; }
    public bool IsAsc { get; init; }
    public int UserId { get; init; }
}
