using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Foundation.Repository;

public class TagRepository : ITagRepository
{
    private readonly DbSet<Tag> DbSet;

    public TagRepository( MaryFoodDbContext dbContext )
    {
        DbSet = dbContext.Set<Tag>();
    }

    public void Add( Tag item )
    {
        Tag tag = DbSet.FirstOrDefault( t => t.Name == item.Name );

        if ( tag == null )
        {
            DbSet.Add( item );
        }
    }

    public async Task<Tag> Get( int id )
    {
        return await DbSet.FirstOrDefaultAsync( t => t.Id == id );
    }

    public async Task<Tag> GetByNameAsync( string name )
    {
        return await DbSet.FirstOrDefaultAsync( t => t.Name == name );
    }

    public void Remove( Tag item )
    {
        DbSet.Remove( item );
    }
}
