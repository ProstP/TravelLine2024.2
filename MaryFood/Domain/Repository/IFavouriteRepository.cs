using Domain.Entity;

namespace Domain.Repository
{
    public interface IFavouriteRepository : IRepository<Favourite>
    {
        Favourite? Get( int id );

        List<Favourite> GetByUserID( int userId );
        List<Favourite> GetByRecipeID( int recipeId );
    }
}
