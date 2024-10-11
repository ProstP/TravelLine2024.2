using Domain.Entity;

namespace Domain.Repository
{
    public interface IRecipeStepRepository : IRepository<RecipeStep>
    {
        RecipeStep? Get( int id );

        List<RecipeStep> GetByRecipeId( int recipeId );
    }
}
