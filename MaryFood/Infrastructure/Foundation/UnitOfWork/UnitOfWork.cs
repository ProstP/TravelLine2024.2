using Application.UnitOfWork;

namespace Infrastructure.Foundation.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        MaryFoodDbContext _dbContext;

        public UnitOfWork( MaryFoodDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
