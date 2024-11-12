using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Foundation.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure( EntityTypeBuilder<User> builder )
    {
        builder.ToTable( nameof( User ) )
               .HasKey( u => u.Id );

        builder.Property( u => u.Login )
               .HasMaxLength( 50 )
               .IsRequired();

        builder.Property( u => u.PasswordHash )
               .HasMaxLength( 100 )
               .IsRequired();

        builder.Property( u => u.Name )
               .HasMaxLength( 50 );

        builder.Property( u => u.About )
               .HasMaxLength( 250 );

        builder.HasMany<Recipe>()
               .WithOne()
               .HasForeignKey( r => r.UserId );

        builder.HasMany( u => u.Favourites )
               .WithOne()
               .HasForeignKey( f => f.UserId )
               .OnDelete( DeleteBehavior.Restrict );

        builder.HasMany( u => u.Likes )
               .WithOne()
               .HasForeignKey( l => l.UserId )
               .OnDelete( DeleteBehavior.Restrict );
    }
}
