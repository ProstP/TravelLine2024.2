using Domain.Entity;

namespace Domain.Repository;

public interface ITagRepository : IRepository<Tag>
{
    Task<Tag> Get( int id );

    Task<List<Tag>> GetAll();

    Tag GetByName( string name );
}
