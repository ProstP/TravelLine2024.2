using Infrastructure.Foundation.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Foundation;
public class MaryFoodDbContext : DbContext
{
    public MaryFoodDbContext( DbContextOptions<MaryFoodDbContext> options )
        : base( options )
    { }


    /*
    protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
    {
        base.OnConfiguring( optionsBuilder );

        optionsBuilder.UseSqlServer( "Server=LAPTOP-U0R8E398\\SQLEXPRESS;Database=MaryFood;Trusted_Connection=True;TrustServerCertificate=True;" );
    }
    */

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );

        modelBuilder.ApplyConfiguration( new UserConfiguration() );
        modelBuilder.ApplyConfiguration( new RecipeConfiguration() );
        modelBuilder.ApplyConfiguration( new TagConfiguration() );
        modelBuilder.ApplyConfiguration( new DefaultTagConfiguration() );
        modelBuilder.ApplyConfiguration( new IngredientConfiguration() );
        modelBuilder.ApplyConfiguration( new RecipeStepConfiduration() );
        modelBuilder.ApplyConfiguration( new FavouriteConfiguration() );
        modelBuilder.ApplyConfiguration( new LikeConfiguration() );
    }
}
