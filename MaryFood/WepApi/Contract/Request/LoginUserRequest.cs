﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Contract.Request;

public class LoginUserRequest
{
    [Required]
    [MaxLength( 50 )]
    public string Login { get; init; }
    [Required]
    [MaxLength( 50 )]
    public string Password { get; init; }
}
