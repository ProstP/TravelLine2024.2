namespace Domain.Entity
{
    public class Ingredient
    {
        public int Id { get; private init; }
        public string Header { get; private set; }
        public string SubIngredients { get; private set; }

        public int RecipeId { get; private init; }

        public Ingredient( int id, string header, string subIngredients, int recipeId )
        {
            Id = id;
            if ( String.IsNullOrWhiteSpace( header ) )
            {
                throw new ArgumentNullException( "Header is null or white spaces" );
            }
            Header = header;
            if ( String.IsNullOrWhiteSpace( subIngredients ) )
            {
                throw new ArgumentNullException( "Ingredients is null or white spaces" );
            }
            SubIngredients = subIngredients;
            RecipeId = recipeId;
        }

        public void Update( string header, string subIngredients )
        {
            if ( String.IsNullOrWhiteSpace( header ) )
            {
                throw new ArgumentNullException( "Header is null or white spaces" );
            }
            Header = header;
            if ( String.IsNullOrWhiteSpace( subIngredients ) )
            {
                throw new ArgumentNullException( "Ingredients is null or white spaces" );
            }
            SubIngredients = subIngredients;
        }
    }
}
