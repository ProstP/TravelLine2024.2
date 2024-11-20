namespace Domain.Entity;

public class Ingredient : Entity
{
    public string Header { get; private set; }
    public string SubIngredients { get; private set; }

    public int RecipeId { get; private init; }

    public Ingredient( string header, string subIngredients, int recipeId )
    {
        if ( string.IsNullOrWhiteSpace( header ) )
        {
            throw new ArgumentNullException( nameof( header ), "Invalid header" );
        }
        Header = header;
        if ( string.IsNullOrWhiteSpace( subIngredients ) )
        {
            throw new ArgumentNullException( nameof( subIngredients ), "Invalid subIngredients" );
        }
        SubIngredients = subIngredients;
        RecipeId = recipeId;
    }

    public void Update( string header, string subIngredients )
    {
        if ( string.IsNullOrWhiteSpace( header ) )
        {
            throw new ArgumentNullException( nameof( header ), "Invalid header" );
        }
        Header = header;
        if ( string.IsNullOrWhiteSpace( subIngredients ) )
        {
            throw new ArgumentNullException( nameof( subIngredients ), "Invalid subIngredients" );
        }
        SubIngredients = subIngredients;
    }
}
