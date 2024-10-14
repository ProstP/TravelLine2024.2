using Domain.Entity;

namespace Domain.Repository
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
        Ingredient Get( int id );

        List<Ingredient> GetByRecipeId( int recipeId );

        Ingredient Update( int id, Ingredient ingredient );
    }
}
