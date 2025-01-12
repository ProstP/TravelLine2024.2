using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Foundation.EntityConfiguration;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure( EntityTypeBuilder<Recipe> builder )
    {
        builder.ToTable( nameof( Recipe ) )
               .HasKey( r => r.Id );

        builder.Property( r => r.Name )
               .HasMaxLength( 50 )
               .IsRequired();

        builder.Property( r => r.Description )
               .HasMaxLength( 150 );

        builder.Property( r => r.CookingTime )
               .IsRequired();

        builder.Property( r => r.PersonNum )
               .IsRequired();

        builder.Property( r => r.Image )
               .HasMaxLength( 100 )
               .IsRequired();

        builder.Property( r => r.CreatedDate )
               .IsRequired();

        builder.HasMany( r => r.Steps )
               .WithOne()
               .HasForeignKey( s => s.RecipeId )
               .OnDelete( DeleteBehavior.Cascade );

        builder.HasMany( r => r.Ingredients )
               .WithOne()
               .HasForeignKey( i => i.RecipeId )
               .OnDelete( DeleteBehavior.Cascade );

        builder.HasMany( r => r.Tags )
               .WithMany( t => t.Recipes )
               .UsingEntity( j => j.ToTable( "RecipeToTag" ) );

        builder.HasMany( r => r.Favourites )
               .WithOne()
               .HasForeignKey( f => f.RecipeId )
               .OnDelete( DeleteBehavior.Cascade );

        builder.HasMany( r => r.Likes )
               .WithOne()
               .HasForeignKey( l => l.RecipeId )
               .OnDelete( DeleteBehavior.Cascade );
    }
}
