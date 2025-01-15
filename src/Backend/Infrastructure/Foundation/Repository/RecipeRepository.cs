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
        Recipe recipe = await DbSet.Include( r => r.Tags )
                                   .Include( r => r.Ingredients )
                                   .Include( r => r.Steps )
                                   .FirstOrDefaultAsync( r => r.Id == id );

        recipe.LikeCount = await DbContext.Set<Like>()
                                          .Where( l => l.RecipeId == recipe.Id )
                                          .CountAsync();
        recipe.FavouriteCount = await DbContext.Set<Favourite>()
                                          .Where( f => f.RecipeId == recipe.Id )
                                          .CountAsync();

        return recipe;
    }

    public async Task<List<Recipe>> GetByUserId( int skip, int take, int userId )
    {
        List<Recipe> list = await DbSet.Where( r => r.UserId == userId )
                                       .Include( r => r.Tags )
                                       .OrderByDescending( r => r.CreatedDate )
                                       .Skip( skip )
                                       .Take( take )
                                       .ToListAsync();

        var likes = await DbContext.Set<Like>()
                                   .GroupBy( l => l.RecipeId )
                                   .Select( g => new
                                   {
                                       RecipeId = g.Key,
                                       Count = g.Count()
                                   } )
                                   .ToListAsync();

        var favourites = await DbContext.Set<Favourite>()
                                        .GroupBy( f => f.RecipeId )
                                        .Select( g => new
                                        {
                                            RecipeId = g.Key,
                                            Count = g.Count()
                                        } )
                                        .ToListAsync();

        list.ForEach( r =>
        {
            var likeGroup = likes.FirstOrDefault( l => l.RecipeId == r.Id );
            r.LikeCount = likeGroup == null ? 0 : likeGroup.Count;
            var favouriteGroup = favourites.FirstOrDefault( f => f.RecipeId == r.Id );
            r.FavouriteCount = favouriteGroup == null ? 0 : favouriteGroup.Count;
        } );

        return list;
    }

    public async Task<List<Recipe>> GetList( int skip, int take,
                                            Func<Recipe, object> orderFunc,
                                            Expression<Func<Recipe, bool>> selectingExpression,
                                            bool isAsc )
    {
        var likes = await DbContext.Set<Like>()
                                   .GroupBy( l => l.RecipeId )
                                   .Select( g => new
                                   {
                                       RecipeId = g.Key,
                                       Count = g.Count()
                                   } )
                                   .ToListAsync();

        var favourites = await DbContext.Set<Favourite>()
                                        .GroupBy( f => f.RecipeId )
                                        .Select( g => new
                                        {
                                            RecipeId = g.Key,
                                            Count = g.Count()
                                        } )
                                        .ToListAsync();

        List<Recipe> list = await DbSet.Include( r => r.Tags )
                                        .Where( selectingExpression )
                                        .ToListAsync();

        list.ForEach( r =>
        {
            var likeGroup = likes.FirstOrDefault( l => l.RecipeId == r.Id );
            r.LikeCount = likeGroup == null ? 0 : likeGroup.Count;
            var favouriteGroup = favourites.FirstOrDefault( f => f.RecipeId == r.Id );
            r.FavouriteCount = favouriteGroup == null ? 0 : favouriteGroup.Count;
        } );

        if ( isAsc )
        {
            list = list.OrderBy( orderFunc ).ToList();
        }
        else
        {
            list = list.OrderByDescending( orderFunc ).ToList();
        }

        List<Recipe> recipes = list.Skip( skip )
                                   .Take( take )
                                   .ToList();

        return recipes;
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
