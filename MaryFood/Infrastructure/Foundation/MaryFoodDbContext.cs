using Infrastructure.Foundation.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Foundation;
public class MaryFoodDbContext : DbContext
{
    public MaryFoodDbContext( DbContextOptions<MaryFoodDbContext> options )
        : base( options )
    { }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );

        modelBuilder.ApplyConfigurationsFromAssembly( typeof( UserConfiguration ).Assembly );
        modelBuilder.ApplyConfigurationsFromAssembly( typeof( RecipeConfiguration ).Assembly );
        modelBuilder.ApplyConfigurationsFromAssembly( typeof( TagConfiguration ).Assembly );
        modelBuilder.ApplyConfigurationsFromAssembly( typeof( MainTagConfiguration ).Assembly );
        modelBuilder.ApplyConfigurationsFromAssembly( typeof( IngredientConfiguration ).Assembly );
        modelBuilder.ApplyConfigurationsFromAssembly( typeof( RecipeStepConfiduration ).Assembly );
        modelBuilder.ApplyConfigurationsFromAssembly( typeof( FavouriteConfiguration ).Assembly );
        modelBuilder.ApplyConfigurationsFromAssembly( typeof( LikeConfiguration ).Assembly );
    }
}
