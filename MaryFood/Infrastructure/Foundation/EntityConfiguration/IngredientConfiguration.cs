using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Foundation.EntityConfiguration;

public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure( EntityTypeBuilder<Ingredient> builder )
    {
        builder.ToTable( nameof( Ingredient ) )
               .HasKey( i => i.Id );

        builder.Property( i => i.Header )
               .HasMaxLength( 50 )
               .IsRequired();

        builder.Property( i => i.SubIngredients )
               .HasMaxLength( 250 )
               .IsRequired();
    }
}
