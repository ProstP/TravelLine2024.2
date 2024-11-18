﻿using Domain.Entity;
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
        return await DbSet.Include( r => r.Ingredients )
                          .Include( r => r.Steps )
                          .Include( r => r.Favourites )
                          .Include( r => r.Likes )
                          .FirstOrDefaultAsync( r => r.Id == id );
    }

    public async Task<List<Recipe>> GetGroup( int skip, int take )
    {
        return await DbSet.Include( r => r.Ingredients )
                          .Include( r => r.Steps )
                          .Include( r => r.Favourites )
                          .Include( r => r.Likes )
                          .Skip( skip )
                          .Take( take )
                          .ToListAsync();
    }

    public async Task<List<Recipe>> GetByName( string name )
    {
        return await DbSet.Where( r => r.Name == name )
                          .Include( r => r.Ingredients )
                          .Include( r => r.Steps )
                          .Include( r => r.Favourites )
                          .Include( r => r.Likes )
                          .ToListAsync();
    }

    public async Task<List<Recipe>> GetByUserId( int userId )
    {
        return await DbSet.Where( r => r.UserId == userId )
                          .Include( r => r.Ingredients )
                          .Include( r => r.Steps )
                          .Include( r => r.Favourites )
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
