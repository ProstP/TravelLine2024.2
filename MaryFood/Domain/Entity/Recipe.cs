namespace Domain.Entity;
public class Recipe
{
    public int Id { get; private init; }
    public string Name { get; private init; }
    public string Description { get; private init; }
    public int CookingTime { get; private init; }
    public int PersonNum { get; private init; }
    public string Image { get; private init; }

    public int UserId { get; private init; }

    [System.Text.Json.Serialization.JsonIgnore]
    public List<RecipeStep> Steps { get; private init; } = new();

    [System.Text.Json.Serialization.JsonIgnore]
    public List<Ingredient> Ingredients { get; private init; } = new();

    public Recipe( int id, string name, string description, int cookingTime, int personNum, string image, int userId )
    {
        Id = id;
        Name = name;
        Description = description;
        CookingTime = cookingTime;
        PersonNum = personNum;
        Image = image;
        UserId = userId;
    }
}
