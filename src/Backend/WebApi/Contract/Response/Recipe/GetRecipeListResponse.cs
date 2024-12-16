﻿namespace WebApi.Contract.Response.Recipe;

public class GetRecipeListResponse
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public int CookingTime { get; init; }
    public int PersonNum { get; init; }
    public string Image { get; init; }
    public DateTime CreatedDate { get; init; }

    public int UserId;
    public List<string> Tags { get; init; } = [];
}
