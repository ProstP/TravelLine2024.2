using Domain.Entity;

namespace Domain.Repository
{
    public interface ITagRepository : IRepository<Tag>
    {
        public Tag? Get( int id );

        public Tag? GetByName( string name );
    }
}
