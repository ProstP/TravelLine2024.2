using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Foundation.Repository
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository( MaryFoodDbContext dbContext )
            : base( dbContext )
        { }

        public async Task<Tag> Get( int id )
        {
            return await _dbContext.Set<Tag>().FirstAsync( t => t.Id == id );
        }

        public async Task<List<Tag>> GetAll()
        {
            return await _dbContext.Set<Tag>().ToListAsync();
        }

        public Tag GetByName( string name )
        {
            return _dbContext.Set<Tag>().FirstOrDefault( t => t.Name == name );
        }
    }
}
