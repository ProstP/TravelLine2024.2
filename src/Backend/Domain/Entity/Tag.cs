namespace Domain.Entity;

public class Tag : Entity
{
    public string Name { get; private init; }

    public List<Recipe> Recipes { get; private init; } = new();

    public Tag( string name )
    {
        if ( string.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentNullException( nameof( name ), "Invalid name" );
        }
        Name = name;
    }
}
