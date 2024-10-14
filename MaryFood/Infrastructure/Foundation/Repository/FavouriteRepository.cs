using Domain.Entity;
using Domain.Repository;

namespace Infrastructure.Foundation.Repository
{
    public class FavouriteRepository : Repository<Favourite>, IFavouriteRepository
    {
        public FavouriteRepository( MaryFoodDbContext dbContext )
            : base( dbContext )
        { }

        public List<Favourite> GetByRecipeID( int recipeId )
        {
            return _dbContext.Set<Favourite>().Where( f => f.RecipeId == recipeId ).ToList();
        }

        public List<Favourite> GetByUserID( int userId )
        {
            return _dbContext.Set<Favourite>().Where( f => f.UserId == userId ).ToList();
        }
    }
}
