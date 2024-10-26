namespace Domain.Entity;

public class Tag : Entity
{
    public string Name { get; private init; }
    public string Description { get; private init; }

    public List<Recipe> Recipes { get; private init; } = new();

    public Tag( string name, string description )
    {
        if ( String.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentNullException( "Invalid name", nameof( name ) );
        }
        Name = name;
        Description = description;
    }
}
