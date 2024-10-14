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
            Header = header;
            SubIngredients = subIngredients;
            RecipeId = recipeId;
        }

        public void Update( string header, string subIngredients )
        {
            Header = header;
            SubIngredients = subIngredients;
        }
    }
}
