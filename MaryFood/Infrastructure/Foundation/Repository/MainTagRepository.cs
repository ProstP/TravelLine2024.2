using Domain.Entity;
using Domain.Repository;

namespace Infrastructure.Foundation.Repository
{
    public class MainTagRepository : IMainTagRepository
    {
        protected readonly MaryFoodDbContext _dbContext;

        public MainTagRepository( MaryFoodDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public List<MainTag> Get()
        {
            return _dbContext.Set<MainTag>().Take( 4 ).ToList();
        }
    }
}
