using System.ComponentModel.DataAnnotations;

namespace WebApi.Contract.Request.Recipe;

public class CreateRecipeStepRequest
{
    [Required]
    public int StepNum { get; init; }

    [Required]
    [MinLength( 1 )]
    [MaxLength( 250 )]
    public string Description { get; init; }
}
