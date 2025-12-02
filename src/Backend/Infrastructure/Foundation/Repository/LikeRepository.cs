using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Foundation.Repository;

public class LikeRepository : Repository<Like>, ILikeRepository
{
    public LikeRepository( MaryFoodDbContext dbContext )
        : base( dbContext )
    { }

    public async Task<int> GetByRecipeId( int recipeId )
    {
        return await DbSet.Where( l => l.RecipeId == recipeId )
                          .CountAsync();
    }

    public async Task<int> GetByUserId( int userId )
    {
        return await DbSet.Where( l => l.UserId == userId )
                          .CountAsync();
    }

    public Task<bool> IsExist( int userId, int recipeId )
    {
        return DbSet.AnyAsync( l => l.UserId == userId && l.RecipeId == recipeId );
    }
}
