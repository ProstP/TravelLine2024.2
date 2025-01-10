using System.ComponentModel.DataAnnotations;

namespace WebApi.Contract.Request.Recipe;

public class CreateRecipeRequest
{
    [Required]
    [MinLength( 1 )]
    [MaxLength( 50 )]
    public string Name { get; init; }

    [MaxLength( 150 )]
    public string Description { get; init; }

    private int cookingTime;
    [Required]
    public int CookingTime
    {
        get => cookingTime;
        init => cookingTime = value > 150 ? 150 : value < 0 ? 0 : value;
    }

    private int personNum;
    [Required]
    public int PersonNum
    {
        get => personNum;
        init => personNum = value > 15 ? 15 : value < 1 ? 1 : value;
    }

    [Required]
    public string Image { get; init; }

    public List<CreateIngredientsRequest> Ingredients { get; init; } = [];
    public List<CreateRecipeStepRequest> RecipeSteps { get; init; } = [];
    public List<string> Tags { get; init; } = new();
}
