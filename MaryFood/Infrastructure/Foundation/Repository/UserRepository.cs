using Domain.Entity;
using Domain.Repository;

namespace Infrastructure.Foundation.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository( MaryFoodDbContext dbContext )
            : base( dbContext )
        { }

        public User? Get( int id )
        {
            return _dbContext.Set<User>().FirstOrDefault( u => u.Id == id );
        }
    }
}
