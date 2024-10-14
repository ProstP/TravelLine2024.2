using Domain.Entity;

namespace Domain.Repository
{
    public interface ITagRepository : IRepository<Tag>
    {
        Tag Get( int id );

        List<Tag> GetAll();

        Tag GetByName( string name );
    }
}
