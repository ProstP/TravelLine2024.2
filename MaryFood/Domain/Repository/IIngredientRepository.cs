using Domain.Entity;

namespace Domain.Repository
{
    public interface IIngredientRepository : IRepository<RecipeStep>
    {
        Ingredient? Get( int id );

        List<Ingredient> GetByRecipeId( int recipeId );
    }
}
