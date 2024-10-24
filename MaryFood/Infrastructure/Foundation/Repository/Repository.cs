using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Foundation.Repository;

public class Repository<T> : IRepository<T>
    where T : class
{
    protected readonly DbSet<T> DbSet;

    public Repository( MaryFoodDbContext dbContext )
    {
        DbSet = dbContext.Set<T>();
    }

    public void Add( T item )
    {
        DbSet.Add( item );
    }

    public void Remove( T item )
    {
        DbSet.Remove( item );
    }
}
