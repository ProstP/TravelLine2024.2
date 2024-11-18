using System.ComponentModel.DataAnnotations;

namespace WebApi.Contract.Request;

public class UpdateUserRequest
{
    [Required]
    [MinLength( 1 )]
    [MaxLength( 50 )]
    public string Name { get; init; }

    [Required]
    [MinLength( 1 )]
    [MaxLength( 50 )]
    public string Login { get; init; }

    [MaxLength( 50 )]
    public string Password { get; init; }

    [MaxLength( 250 )]
    public string About { get; init; }
}
