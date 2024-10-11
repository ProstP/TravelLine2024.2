using Domain.Repository;

namespace Infrastructure.Foundation.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        protected readonly MaryFoodDbContext _dbContext;

        public Repository( MaryFoodDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Create( T item )
        {
            _dbContext.Set<T>().Add( item );
            _dbContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Remove( T item )
        {
            _dbContext.Set<T>().Remove( item );
            _dbContext.SaveChanges();
        }
    }
}
