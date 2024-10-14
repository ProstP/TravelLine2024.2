using Domain.Entity;

namespace Domain.Repository
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Recipe Get( int id );

        List<Recipe> GetAll();

        List<Recipe> GetByUserId( int userId );

        List<Recipe> GetByName( string name );

        Recipe Update( int id, Recipe recipe );
    }
}
