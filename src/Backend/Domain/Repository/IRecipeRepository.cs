﻿using System.Linq.Expressions;
using Domain.Entity;

namespace Domain.Repository;

public interface IRecipeRepository : IRepository<Recipe>
{
    Task<Recipe> Get( int id );

    Task<List<Recipe>> GetList( int skip, int take,
                                Expression<Func<Recipe, object>> orderExpression,
                                Expression<Func<Recipe, bool>> userSelectingExpression,
                                Expression<Func<Recipe, bool>> selectingExpression,
                                bool isAsc = false );

    Recipe Update( int id, Recipe recipe );
}
