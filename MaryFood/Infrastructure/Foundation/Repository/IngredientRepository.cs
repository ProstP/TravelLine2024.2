using Domain.Entity;
using Domain.Repository;

namespace Infrastructure.Foundation.Repository
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository( MaryFoodDbContext dbContext )
            : base( dbContext )
        { }

        public Ingredient Get( int id )
        {
            return _dbContext.Set<Ingredient>().FirstOrDefault( rs => rs.Id == id );
        }

        public List<Ingredient> GetByRecipeId( int recipeId )
        {
            return _dbContext.Set<Ingredient>().Where( rs => rs.RecipeId == recipeId ).ToList();
        }

        public Ingredient Update( int id, Ingredient ingredient )
        {
            var old = _dbContext.Set<Ingredient>().FirstOrDefault( i => i.Id == id );
            if ( old == null )
            {
                return null;
            }

            _dbContext.Update( ingredient );

            return ingredient;
        }
    }
}
