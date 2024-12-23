using Application.CQRSInterfaces;
using Application.Result;
using Application.UseCases.Recipe.Dtos;
using Domain.Repository;

namespace Application.UseCases.Recipe.Query.GetRecipeListByUserQuery;

public class GetRecipeListByUserQueryHandler : IQueryHandler<List<RecipeDto>, GetRecipeListByUserQuery>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUserRepository _userRepository;

    public GetRecipeListByUserQueryHandler( IRecipeRepository recipeRepository, IUserRepository userRepository )
    {
        _recipeRepository = recipeRepository;
        _userRepository = userRepository;
    }

    public async Task<Result<List<RecipeDto>>> HandleAsync( GetRecipeListByUserQuery query )
    {
        Domain.Entity.User user = await _userRepository.GetByLogin( query.UserLogin );

        if ( user == null )
        {
            return Result<List<RecipeDto>>.FromError( "Unknown user" );
        }

        List<Domain.Entity.Recipe> recipes = await _recipeRepository.GetByUserId( ( query.GroupNum - 1 ) * query.Count, query.Count, user.Id );

        List<RecipeDto> result = recipes.Select( r => new RecipeDto()
        {
            Id = r.Id,
            Name = r.Name,
            Description = r.Description,
            CookingTime = r.CookingTime,
            PersonNum = r.PersonNum,
            Image = r.Image,
            CreatedDate = r.CreatedDate,
            UserId = user.Id,
            Tags = r.Tags.Select( t => t.Name ).ToList()
        } ).ToList();

        return Result<List<RecipeDto>>.FromSuccess( result );
    }
}
