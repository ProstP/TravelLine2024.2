using Domain.Entity;

namespace Domain.Repository
{
    public interface IFavouriteRepository : IRepository<Favourite>
    {
        List<Favourite> GetByUserID( int userId );
        List<Favourite> GetByRecipeID( int recipeId );
    }
}
