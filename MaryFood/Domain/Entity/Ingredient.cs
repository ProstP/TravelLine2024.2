namespace Domain.Entity;

public class Ingredient : Entity
{
    public string Header { get; private set; }
    public string SubIngredients { get; private set; }

    public int RecipeId { get; private init; }

    public Ingredient( string header, string subIngredients, int recipeId )
    {
        if ( String.IsNullOrWhiteSpace( header ) )
        {
            throw new ArgumentNullException( "Invalid header", nameof( header ) );
        }
        Header = header;
        if ( String.IsNullOrWhiteSpace( subIngredients ) )
        {
            throw new ArgumentNullException( "Invalid subIngredients", nameof( subIngredients ) );
        }
        SubIngredients = subIngredients;
        RecipeId = recipeId;
    }

    public void Update( string header, string subIngredients )
    {
        if ( String.IsNullOrWhiteSpace( header ) )
        {
            throw new ArgumentNullException( "Invalid header", nameof( header ) );
        }
        Header = header;
        if ( String.IsNullOrWhiteSpace( subIngredients ) )
        {
            throw new ArgumentNullException( "Invalid subIngredients", nameof( subIngredients ) );
        }
        SubIngredients = subIngredients;
    }
}
