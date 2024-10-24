using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Foundation.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository( MaryFoodDbContext dbContext )
        : base( dbContext )
    { }

    public async Task<User> Get( int id )
    {
        return await DbSet.Include( u => u.Favourite )
                          .Include( u => u.Like )
                          .FirstAsync( u => u.Id == id );
    }

    public async Task<User> GetByLodin( string login )
    {
        return await DbSet.FirstAsync( u => u.Login == login );
    }

    public User Update( int id, User user )
    {
        var old = DbSet.FirstOrDefault( u => u.Id == id );
        if ( old == null )
        {
            return null;
        }

        DbSet.Update( user );
        return user;
    }
}
