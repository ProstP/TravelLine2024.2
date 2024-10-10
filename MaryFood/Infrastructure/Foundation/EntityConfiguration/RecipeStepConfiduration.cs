using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Foundation.EntityConfiguration
{
    public class RecipeStepConfiduration : IEntityTypeConfiguration<RecipeStep>
    {
        public void Configure( EntityTypeBuilder<RecipeStep> builder )
        {
            builder.ToTable( nameof( RecipeStep ) )
                .HasKey( rs => rs.Id );

            builder.Property( rs => rs.StepNum )
                .IsRequired();

            builder.Property( rs => rs.Description )
                .HasMaxLength( 250 )
                .IsRequired();
        }
    }
}
