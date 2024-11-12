﻿namespace Domain.Entity;

public class RecipeStep : Entity
{
    public int StepNum { get; private set; }
    public string Description { get; private set; }

    public int RecipeId { get; private init; }

    public RecipeStep( int id, int stepNum, string description, int recipeId )
    {
        Id = id;
        StepNum = stepNum;
        if ( string.IsNullOrWhiteSpace( description ) )
        {
            throw new ArgumentNullException( nameof( description ), "Invalid description" );
        }
        Description = description;
        RecipeId = recipeId;
    }

    public void Update( int stepNum, string description )
    {
        StepNum = stepNum;
        if ( string.IsNullOrWhiteSpace( description ) )
        {
            throw new ArgumentNullException( nameof( description ), "Invalid description" );
        }
        Description = description;
    }
}