namespace Domain.Repository
{
    public interface IRepository<T>
        where T : class
    {
        List<T> GetAll();
        void Create( T item );
        void Remove( T item );
    }
}
