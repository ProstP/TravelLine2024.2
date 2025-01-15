using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Foundation.Repository;

public class Repository<T> : IRepository<T>
    where T : class
{
    protected MaryFoodDbContext DbContext;
    protected DbSet<T> DbSet => DbContext.Set<T>();

    public Repository( MaryFoodDbContext dbContext )
    {
        DbContext = dbContext;
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
