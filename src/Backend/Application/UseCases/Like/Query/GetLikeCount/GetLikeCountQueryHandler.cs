using Application.CQRSInterfaces;
using Application.Result;
using Domain.Repository;

namespace Application.UseCases.Like.Query.GetLikeCount;

public class GetLikeCountQueryHandler : IQueryHandler<GetLikeCountResult, GetLikeCountQuery>
{
    private readonly ILikeRepository _likeRepository;

    public GetLikeCountQueryHandler( ILikeRepository likeRepository )
    {
        _likeRepository = likeRepository;
    }

    public async Task<Result<GetLikeCountResult>> HandleAsync( GetLikeCountQuery query )
    {
        int count;

        try
        {
            if ( query.FromRecipe )
            {
                count = await _likeRepository.GetByRecipeId( query.Id );
            }
            else
            {
                count = await _likeRepository.GetByUserId( query.Id );
            }

            GetLikeCountResult result = new()
            {
                Count = count,
            };

            return Result<GetLikeCountResult>.FromSuccess( result );
        }
        catch ( Exception ex )
        {
            return Result<GetLikeCountResult>.FromError( ex.Message );
        }
    }
}
