namespace Domain.Entity
{
    public class Ingredient
    {
        public int Id { get; private init; }
        public string Header { get; private init; }
        public string IngredientList { get; private init; }

        public int RecipeId { get; private init; }

        public Ingredient( int id, string header, string ingredientList, int recipeId )
        {
            Id = id;
            Header = header;
            IngredientList = ingredientList;
            RecipeId = recipeId;
        }
    }
}
