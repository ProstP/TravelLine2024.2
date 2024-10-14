namespace Domain.Entity;
public class Recipe
{
    public int Id { get; private init; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int CookingTime { get; private set; }
    public int PersonNum { get; private set; }
    public string Image { get; private set; }

    public int UserId { get; private init; }

    [System.Text.Json.Serialization.JsonIgnore]
    public List<RecipeStep> Steps { get; private init; } = new();

    [System.Text.Json.Serialization.JsonIgnore]
    public List<Ingredient> Ingredients { get; private init; } = new();

    [System.Text.Json.Serialization.JsonIgnore]
    public List<Favourite> Favourite { get; private init; } = new();

    [System.Text.Json.Serialization.JsonIgnore]
    public List<Like> Like { get; private init; } = new();

    [System.Text.Json.Serialization.JsonIgnore]
    public List<Tag> Tags { get; private init; } = new();

    public Recipe( int id, string name, string description, int cookingTime, int personNum, string image, int userId )
    {
        Id = id;
        if ( string.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentNullException( "Name is empty or white spaces" );
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
            throw new ArgumentNullException( "Name is empty or white spaces" );
        }
        Name = name;
        Description = description;
        CookingTime = cookingTime;
        PersonNum = personNum;
        Image = image;
    }
}
