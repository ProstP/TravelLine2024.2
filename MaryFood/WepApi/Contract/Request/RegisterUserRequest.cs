using System.ComponentModel.DataAnnotations;

namespace WebApi.Contract.Request;

public class RegisterUserRequest
{
    [Required]
    [MinLength( 1 )]
    [MaxLength( 50 )]
    public string Name { get; init; }

    [Required]
    [MinLength( 1 )]
    [MaxLength( 50 )]
    public string Login { get; init; }

    [Required]
    [MinLength( 8 )]
    [MaxLength( 50 )]
    public string Password { get; init; }
}
