using Domain.Entity;

namespace Domain.Repository;

public interface ITagRepository : IRepository<Tag>
{
    Task<Tag> Get( int id );

    Task<Tag> GetByNameAsync( string name );
}
