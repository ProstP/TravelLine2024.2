using Application.Result;
using Application.UseCases.Recipe.Dtos;
using Application.UseCases.Recipe.Query.GetRecipeListQuery;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contract.Request.Recipe;
using WebApi.Contract.Response.Recipe;

namespace WebApi.Controller;

[ApiController]
[Route( "api/recipes" )]
public class RecipeListController : ControllerBase
{
    private readonly GetRecipeListQueryHandler _getRecipeListQueryHandler;

    public RecipeListController( GetRecipeListQueryHandler getRecipeListQueryHandler )
    {
        _getRecipeListQueryHandler = getRecipeListQueryHandler;
    }

    [HttpPost]
    public async Task<ActionResult<List<GetRecipeListResponse>>> GetList( [FromBody] GetRecipeListRequest request )
    {
        GetRecipeListQuery query = new()
        {
            GroupNum = request.GroupNum,
            Count = request.Count,
            IsAsc = request.IsAsc,
            OrderType = request.OrderType,
            UserId = request.UserId,
            SearchName = request.SearchName,
        };

        Result<List<RecipeDto>> result = await _getRecipeListQueryHandler.HandleAsync( query );

        if ( !result.IsSuccess )
        {
            return BadRequest( result.Error );
        }

        List<GetRecipeListResponse> getRecipeResponses = result.Value.Select( r => new GetRecipeListResponse()
        {
            Id = r.Id,
            Name = r.Name,
            Description = r.Description,
            CookingTime = r.CookingTime,
            PersonNum = r.PersonNum,
            Image = r.Image,
            CreatedDate = r.CreatedDate,
            UserId = r.UserId,
            Tags = r.Tags,
        } ).ToList();

        return Ok( getRecipeResponses );
    }
}
