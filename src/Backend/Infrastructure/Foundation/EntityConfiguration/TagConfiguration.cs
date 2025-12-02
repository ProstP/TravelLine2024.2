using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Foundation.EntityConfiguration;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure( EntityTypeBuilder<Tag> builder )
    {
        builder.ToTable( nameof( Tag ) )
               .HasKey( t => t.Id );

        builder.Property( t => t.Name )
               .HasMaxLength( 20 )
               .IsRequired();

        builder.HasIndex( t => t.Name )
               .IsUnique();
    }
}
