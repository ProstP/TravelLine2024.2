using Domain.Entity;
using Domain.Repository;

namespace Infrastructure.Foundation.Repository
{
    public class LikeRepository : Repository<Like>, ILikeRepository
    {
        public LikeRepository( MaryFoodDbContext dbContext )
            : base( dbContext )
        { }

        public List<Like> GetByRecipeID( int recipeId )
        {
            return _dbContext.Set<Like>().Where( f => f.RecipeId == recipeId ).ToList();
        }

        public List<Like> GetByUserID( int userId )
        {
            return _dbContext.Set<Like>().Where( f => f.UserId == userId ).ToList();
        }
    }
}
