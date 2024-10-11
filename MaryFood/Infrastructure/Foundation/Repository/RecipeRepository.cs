using Domain.Entity;
using Domain.Repository;

namespace Infrastructure.Foundation.Repository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository( MaryFoodDbContext dbContext )
            : base( dbContext )
        { }

        public Recipe? Get( int id )
        {
            return _dbContext.Set<Recipe>().FirstOrDefault( r => r.Id == id );
        }

        public List<Recipe> GetByName( string name )
        {
            return _dbContext.Set<Recipe>().Where( r => r.Name == name ).ToList();
        }

        public List<Recipe> GetByUserId( int userId )
        {
            return _dbContext.Set<Recipe>().Where( r => r.UserId == userId ).ToList();
        }
    }
}
