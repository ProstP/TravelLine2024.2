using Domain.Entity;

namespace Domain.Repository
{
    public interface ILikeRepository : IRepository<Like>
    {
        List<Like> GetByUserID( int userId );
        List<Like> GetByRecipeID( int recipeId );
    }
}
