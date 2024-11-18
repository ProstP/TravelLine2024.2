using Domain.Entity;

namespace Domain.Repository;

public interface IUserRepository : IRepository<User>
{
    Task<User> Get( int id );

    Task<User> GetByLogin( string login );

    User Update( int id, User user );
}
