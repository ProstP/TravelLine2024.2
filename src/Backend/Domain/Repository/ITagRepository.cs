using Domain.Entity;

namespace Domain.Repository;

public interface ITagRepository : IRepository<Tag>
{
    Task<Tag> Get( int id );

    Tag GetByName( string name );
}
