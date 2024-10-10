using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Foundation.EntityConfiguration
{
    public class FavouriteConfiguration : IEntityTypeConfiguration<Favourite>
    {
        public void Configure( EntityTypeBuilder<Favourite> builder )
        {
            builder.ToTable( nameof( Favourite ) )
                .HasKey( f => f.Id );
        }
    }
}
