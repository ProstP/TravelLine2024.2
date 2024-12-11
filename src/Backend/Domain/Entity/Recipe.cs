namespace Domain.Entity;
public class Recipe : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int CookingTime { get; private set; }
    public int PersonNum { get; private set; }
    public string Image { get; private set; }
    public DateTime CreatedDate { get; private init; }

    public int UserId { get; private init; }

    public List<RecipeStep> Steps { get; private init; } = [];
    public List<Ingredient> Ingredients { get; private init; } = [];
    public List<Favourite> Favourites { get; private init; } = [];
    public List<Like> Likes { get; private init; } = [];
    public List<Tag> Tags { get; private init; } = [];

    public Recipe( string name, string description, int cookingTime, int personNum, string image, DateTime createdDate, int userId )
    {
        if ( string.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentNullException( nameof( name ), "Invalid name" );
        }
        Name = name;
        Description = description;
        CookingTime = cookingTime;
        PersonNum = personNum;
        Image = image;
        UserId = userId;
        CreatedDate = createdDate;
    }

    public void Update( string name, string description, int cookingTime, int personNum, string image )
    {
        if ( string.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentNullException( nameof( name ), "Invalid name" );
        }
        Name = name;
        Description = description;
        CookingTime = cookingTime;
        PersonNum = personNum;
        Image = image;
    }
}
