using System.ComponentModel.DataAnnotations;

namespace WebApi.Contract.Request.Recipe;

public class UpdateRecipeRequest
{
    [Required]
    public int Id { get; init; }

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

    public List<UpdateIngredientRequest> Ingredients { get; init; } = [];
    public List<UpdateRecipeStepRequest> RecipeSteps { get; init; } = [];
}
