using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Foundation.EntityConfiguration
{
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
                   .HasMaxLength( 50 )
                   .IsRequired();

            builder.Property( u => u.Name )
                   .HasMaxLength( 50 )
                   .IsRequired();

            builder.Property( u => u.About )
                   .HasMaxLength( 250 );

            builder.HasMany<Recipe>()
                   .WithOne()
                   .HasForeignKey( r => r.UserId );

            builder.HasMany( u => u.Favourite )
                   .WithOne()
                   .HasForeignKey( f => f.UserId )
                   .OnDelete( DeleteBehavior.NoAction );

            builder.HasMany( u => u.Like )
                   .WithOne()
                   .HasForeignKey( l => l.UserId )
                   .OnDelete( DeleteBehavior.NoAction );
        }
    }
}
