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

    [Required]
    public int CookingTime { get; init; }

    [Required]
    public int PersonNum { get; init; }

    [MaxLength( 100 )]
    public string Image { get; init; }

    public List<CreateIngredientsRequest> Ingredients { get; init; } = [];
    public List<CreateRecipeStepRequest> RecipeSteps { get; init; } = [];
}
