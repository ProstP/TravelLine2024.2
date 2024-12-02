using System.ComponentModel.DataAnnotations;

namespace WebApi.Contract.Request.Recipe;

public class UpdateRecipeStepRequest
{
    [Required]
    public int Id { get; init; }

    [Required]
    [MinLength( 1 )]
    [MaxLength( 250 )]
    public string Description { get; init; }
}
