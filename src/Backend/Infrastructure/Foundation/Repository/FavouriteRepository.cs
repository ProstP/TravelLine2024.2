using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Foundation.Repository;

public class FavouriteRepository : Repository<Favourite>, IFavouriteRepository
{
    public FavouriteRepository( MaryFoodDbContext dbContext )
        : base( dbContext )
    { }

    public async Task<int> GetByRecipeId( int recipeId )
    {
        return await DbSet.Where( f => f.RecipeId == recipeId )
                          .CountAsync();
    }

    public async Task<int> GetByUserId( int userId )
    {
        return await DbSet.Where( f => f.UserId == userId )
                          .CountAsync();
    }

    public async Task<bool> IsExist( int userId, int recipeId )
    {
        return await DbSet.AnyAsync( f => f.UserId == userId && f.RecipeId == recipeId );
    }
}
