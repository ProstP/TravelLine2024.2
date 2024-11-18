namespace Domain.Entity;

public class RecipeStep : Entity
{
    public int StepNum { get; private set; }
    public string Description { get; private set; }

    public int RecipeId { get; private init; }

    public RecipeStep( int stepNum, string description )
    {
        StepNum = stepNum;
        if ( string.IsNullOrWhiteSpace( description ) )
        {
            throw new ArgumentNullException( nameof( description ), "Invalid description" );
        }
        Description = description;
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
