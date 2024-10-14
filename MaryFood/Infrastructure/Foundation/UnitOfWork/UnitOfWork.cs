using App.UnitOfWork;

namespace Infrastructure.Foundation.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        MaryFoodDbContext _dbContext;

        public UnitOfWork( MaryFoodDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async void SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
