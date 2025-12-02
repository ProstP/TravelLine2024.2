using Domain.Entity;

namespace Domain.Repository;

public interface IFavouriteRepository : IRepository<Favourite>
{
    Task<bool> IsExist( int userId, int recipeId );
    Task<int> GetByUserId( int userId );
    Task<int> GetByRecipeId( int recipeId );
}
