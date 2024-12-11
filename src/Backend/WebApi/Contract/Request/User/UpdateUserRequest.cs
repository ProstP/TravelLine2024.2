using System.ComponentModel.DataAnnotations;

namespace WebApi.Contract.Request.User;

public class UpdateUserRequest
{
    [MaxLength( 50 )]
    public string Name { get; init; }

    [MaxLength( 50 )]
    public string Login { get; init; }

    [MaxLength( 50 )]
    public string Password { get; init; }

    [MaxLength( 250 )]
    public string About { get; init; }
}
