using Domain.Entity;
using Domain.Repository;

namespace Infrastructure.Foundation.Repository
{
    public class RecipeStepRepository : Repository<RecipeStep>, IRecipeStepRepository
    {
        public RecipeStepRepository( MaryFoodDbContext dbContext )
            : base( dbContext )
        { }

        public RecipeStep Get( int id )
        {
            return _dbContext.Set<RecipeStep>().FirstOrDefault( rs => rs.Id == id );
        }

        public List<RecipeStep> GetByRecipeId( int recipeId )
        {
            return _dbContext.Set<RecipeStep>().Where( rs => rs.RecipeId == recipeId ).ToList();
        }

        public RecipeStep Update( int id, RecipeStep recipeStep )
        {
            var old = _dbContext.Set<RecipeStep>().FirstOrDefault( rs => rs.Id == id );
            if ( old == null )
            {
                return null;
            }

            _dbContext.Update( recipeStep );
            return recipeStep;
        }
    }
}
