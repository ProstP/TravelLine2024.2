using Domain.Entity;

namespace Domain.Repository
{
    public interface ILikeRepository : IRepository<Like>
    {
        Like? Get( int id );

        List<Like> GetByUserID( int userId );
        List<Like> GetByRecipeID( int recipeId );
    }
}
