﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Contract.Request.User;

public class RefreshTokenRequest
{
    [Required]
    [MinLength( 50 )]
    [MaxLength( 300 )]
    public string RefreshToken { get; init; }
}
