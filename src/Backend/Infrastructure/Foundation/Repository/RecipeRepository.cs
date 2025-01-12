using System.Linq.Expressions;
using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Foundation.Repository;

public class RecipeRepository : Repository<Recipe>, IRecipeRepository
{
    public RecipeRepository( MaryFoodDbContext dbContext )
        : base( dbContext )
    { }

    public async Task<Recipe> Get( int id )
    {
        return await DbSet.Include( r => r.Tags )
                          .Include( r => r.Ingredients )
                          .Include( r => r.Steps )
                          .Include( r => r.Favourites )
                          .Include( r => r.Likes )
                          .FirstOrDefaultAsync( r => r.Id == id );
    }

    public async Task<List<Recipe>> GetByUserId( int skip, int take, int userId )
    {
        return await DbSet.Where( r => r.UserId == userId )
                          .OrderByDescending( r => r.CreatedDate )
                          .Skip( skip )
                          .Take( take )
                          .ToListAsync();
    }

    public async Task<List<Recipe>> GetList( int skip, int take,
                                            Expression<Func<Recipe, object>> orderExpression,
                                            Expression<Func<Recipe, bool>> selectingExpression,
                                            bool isAsc )
    {
        IQueryable<Recipe> query
                    = DbSet.Include( r => r.Tags )
                           .Include( r => r.Likes )
                           .Where( selectingExpression );

        if ( isAsc )
        {
            query = query.OrderBy( orderExpression );
        }
        else
        {
            query = query.OrderByDescending( orderExpression );
        }

        return await query.Skip( skip )
                          .Take( take )
                          .ToListAsync();
    }

    public Recipe Update( int id, Recipe recipe )
    {
        Recipe old = DbSet.FirstOrDefault( r => r.Id == id );
        if ( old == null )
        {
            return null;
        }

        DbSet.Update( recipe );
        return recipe;
    }
}
