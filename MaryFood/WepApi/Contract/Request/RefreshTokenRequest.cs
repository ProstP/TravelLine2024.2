using System.ComponentModel.DataAnnotations;

namespace WebApi.Contract.Request;

public class RefreshTokenRequest
{
    [Required]
    [MaxLength( 300)]
    public string RefreshToken { get; init; }
}
