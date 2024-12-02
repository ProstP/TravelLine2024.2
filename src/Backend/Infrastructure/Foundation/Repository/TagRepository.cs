using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Foundation.Repository;

public class TagRepository : Repository<Tag>, ITagRepository
{
    public TagRepository( MaryFoodDbContext dbContext )
        : base( dbContext )
    {
    }

    public async Task<Tag> Get( int id )
    {
        return await DbSet.FirstOrDefaultAsync( t => t.Id == id );
    }

    public Tag GetByName( string name )
    {
        return DbSet.FirstOrDefault( t => t.Name == name );
    }
}
