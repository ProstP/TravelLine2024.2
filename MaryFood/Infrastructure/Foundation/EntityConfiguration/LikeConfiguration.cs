using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Foundation.EntityConfiguration
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure( EntityTypeBuilder<Like> builder )
        {
            builder.ToTable( nameof( Like ) )
                   .HasKey( l => new { l.UserId, l.RecipeId } );
        }
    }
}
