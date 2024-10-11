using Domain.Entity;

namespace Domain.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User? Get( int id );
    }
}
