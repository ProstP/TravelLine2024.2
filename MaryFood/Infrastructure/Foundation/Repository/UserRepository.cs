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
        return await DbSet.Include( u => u.Favourites )
                          .Include( u => u.Likes )
                          .FirstOrDefaultAsync( u => u.Id == id );
    }

    public async Task<User> GetByLogin( string login )
    {
        return await DbSet.FirstOrDefaultAsync( u => u.Login == login );
    }

    public User Update( int id, User user )
    {
        User old = DbSet.FirstOrDefault( u => u.Id == id );
        if ( old == null )
        {
            return null;
        }

        DbSet.Update( user );
        return user;
    }
}
