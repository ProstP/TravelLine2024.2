﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Contract.Request.Recipe;

public class UpdateIngredientRequest
{
    [Required]
    public int Id { get; init; }

    [Required]
    [MinLength( 1 )]
    [MaxLength( 50 )]
    public string Header { get; init; }

    [Required]
    [MinLength( 1 )]
    [MaxLength( 250 )]
    public string SubIngredients { get; init; }
}