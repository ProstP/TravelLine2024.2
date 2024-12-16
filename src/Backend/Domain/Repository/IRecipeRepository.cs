using System.Linq.Expressions;
using Domain.Entity;

namespace Domain.Repository;

public interface IRecipeRepository : IRepository<Recipe>
{
    Task<Recipe> Get( int id );

    Task<List<Recipe>> GetList( int skip, int take, Expression<Func<Recipe, object>> orderExpression, Expression<Func<Recipe, bool>> userSelectingExpression, bool isAsc = false );

    Task<List<Recipe>> GetByName( string name );

    Recipe Update( int id, Recipe recipe );
}
