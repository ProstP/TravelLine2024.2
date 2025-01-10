using Domain.Entity;

namespace Domain.Repository;

public interface ILikeRepository : IRepository<Like>
{
    Task<bool> IsExist( int userId, int recipeId );
    Task<int> GetByUserId( int userId );
    Task<int> GetByRecipeId( int recipeId );
}
