using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Foundation.EntityConfiguration;

public class DefaultTagConfiguration : IEntityTypeConfiguration<DefaultTag>
{
    public void Configure( EntityTypeBuilder<DefaultTag> builder )
    {
        builder.ToTable( nameof( DefaultTag ) )
               .HasKey( mn => mn.Id );
    }
}
