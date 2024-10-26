namespace Domain.Entity;
public class Recipe : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int CookingTime { get; private set; }
    public int PersonNum { get; private set; }
    public string Image { get; private set; }

    public int UserId { get; private init; }

    public List<RecipeStep> Steps { get; private init; } = new();
    public List<Ingredient> Ingredients { get; private init; } = new();
    public List<Favourite> Favourite { get; private init; } = new();
    public List<Like> Like { get; private init; } = new();
    public List<Tag> Tags { get; private init; } = new();

    public Recipe( string name, string description, int cookingTime, int personNum, string image, int userId )
    {
        if ( string.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentNullException( "Invalid name", nameof( name ) );
        }
        Name = name;
        Description = description;
        CookingTime = cookingTime;
        PersonNum = personNum;
        Image = image;
        UserId = userId;
    }

    public void Update( string name, string description, int cookingTime, int personNum, string image )
    {
        if ( string.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentNullException( "Invalid name", nameof( name ) );
        }
        Name = name;
        Description = description;
        CookingTime = cookingTime;
        PersonNum = personNum;
        Image = image;
    }
}
