using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Foundation.EntityConfiguration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure( EntityTypeBuilder<Tag> builder )
        {
            builder.ToTable( nameof( Tag ) )
                .HasKey( t => t.Id );

            builder.Property( t => t.Name )
                .HasMaxLength( 20 )
                .IsRequired();

            builder.Property( t => t.Description )
                .HasMaxLength( 150 );

            builder.HasMany( t => t.Recipes )
                .WithMany( r => r.Tags )
                .UsingEntity( j => j.ToTable( "Recipe-Tag" ) );

            builder.HasOne( t => t.MainTag )
                .WithOne( mt => mt.Tag )
                .HasForeignKey<MainTag>( mn => mn.TagId );
        }
    }
}
