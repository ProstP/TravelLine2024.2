using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Foundation.Repository;

public class DefaultTagRepository : IDefaultTagRepository
{
    protected readonly DbSet<DefaultTag> _dbSet;

    public DefaultTagRepository( MaryFoodDbContext dbContext )
    {
        _dbSet = dbContext.Set<DefaultTag>();
    }

    public async Task<List<DefaultTag>> Get()
    {
        return await _dbSet.Take( 4 ).ToListAsync();
    }
}
