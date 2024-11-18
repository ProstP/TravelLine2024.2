using Domain.Entity;

namespace Domain.Repository;

public interface IRecipeRepository : IRepository<Recipe>
{
    Task<Recipe> Get( int id );

    Task<List<Recipe>> GetGroup(int skip, int take);

    Task<List<Recipe>> GetByUserId( int userId );

    Task<List<Recipe>> GetByName( string name );

    Recipe Update( int id, Recipe recipe );
}
