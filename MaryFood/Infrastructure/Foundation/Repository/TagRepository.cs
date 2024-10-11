using Domain.Entity;
using Domain.Repository;

namespace Infrastructure.Foundation.Repository
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository( MaryFoodDbContext dbContext )
            : base( dbContext )
        { }

        public Tag? Get( int id )
        {
            return _dbContext.Set<Tag>().FirstOrDefault( t => t.Id == id );
        }

        public Tag? GetByName( string name )
        {
            return _dbContext.Set<Tag>().FirstOrDefault( t => t.Name == name );
        }
    }
}
