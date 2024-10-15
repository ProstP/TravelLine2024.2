using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Foundation.Repository
{
    public class DefaultTagRepository : IDefaultTagRepository
    {
        protected readonly MaryFoodDbContext _dbContext;

        public DefaultTagRepository( MaryFoodDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task<List<DefaultTag>> Get()
        {
            return await _dbContext.Set<DefaultTag>().Take( 4 ).ToListAsync();
        }
    }
}
