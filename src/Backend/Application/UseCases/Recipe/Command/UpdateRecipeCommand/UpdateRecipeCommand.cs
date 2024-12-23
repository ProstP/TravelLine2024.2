﻿namespace Application.UseCases.Recipe.Command.UpdateRecipeCommand;

public class UpdateRecipeCommand
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public int CookingTime { get; init; }
    public int PersonNum { get; init; }
    public string Image { get; init; }

    public string UserLogin { get; init; }

    public List<UpdateIngredientCommand> Ingredients { get; init; } = [];
    public List<UpdateRecipeStepCommand> RecipeSteps { get; init; } = [];
    public List<string> Tags { get; init; } = [];
}
