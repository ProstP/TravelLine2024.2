using System.ComponentModel.DataAnnotations;

namespace WebApi.Contract.Request.Recipe;

public class GetRecipeListRequest
{
    private int groupNum;
    [Required]
    public int GroupNum
    {
        get => groupNum;
        init => groupNum = value < 1 ? 1 : value;
    }
    private int count;
    [Required]
    public int Count
    {
        get => count;
        init => count = value < 1 ? 1 : value;
    }
    public string OrderType { get; init; }
    public bool IsAsc { get; init; }
    public int UserId { get; init; }
}
