using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Foundation.EntityConfiguration
{
    public class MainTagConfiguration : IEntityTypeConfiguration<MainTag>
    {
        public void Configure( EntityTypeBuilder<MainTag> builder )
        {
            builder.ToTable( nameof( MainTag ) )
                .HasKey( mn => mn.Id );
        }
    }
}
