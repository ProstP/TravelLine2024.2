using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Foundation.Repository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository( MaryFoodDbContext dbContext )
            : base( dbContext )
        { }

        public async Task<Recipe> Get( int id )
        {
            return await _dbContext.Set<Recipe>()
                                   .Include( r => r.Ingredients )
                                   .Include( r => r.Steps )
                                   .Include( r => r.Favourite )
                                   .Include( r => r.Like )
                                   .FirstAsync( r => r.Id == id );
        }

        public async Task<List<Recipe>> GetAll()
        {
            return await _dbContext.Set<Recipe>()
                                   .Include( r => r.Ingredients )
                                   .Include( r => r.Steps )
                                   .Include( r => r.Favourite )
                                   .Include( r => r.Like )
                                   .ToListAsync();
        }

        public async Task<List<Recipe>> GetByName( string name )
        {
            return await _dbContext.Set<Recipe>()
                             .Where( r => r.Name == name )
                             .Include( r => r.Ingredients )
                             .Include( r => r.Steps )
                             .Include( r => r.Favourite )
                             .Include( r => r.Like )
                             .ToListAsync();
        }

        public async Task<List<Recipe>> GetByUserId( int userId )
        {
            return await _dbContext.Set<Recipe>()
                             .Where( r => r.UserId == userId )
                             .Include( r => r.Ingredients )
                             .Include( r => r.Steps )
                             .Include( r => r.Favourite )
                             .ToListAsync();
        }

        public Recipe Update( int id, Recipe recipe )
        {
            var old = _dbContext.Set<Recipe>().FirstOrDefault( r => r.Id == id );
            if ( old == null )
            {
                return null;
            }

            _dbContext.Update( recipe );
            return recipe;
        }
    }
}
