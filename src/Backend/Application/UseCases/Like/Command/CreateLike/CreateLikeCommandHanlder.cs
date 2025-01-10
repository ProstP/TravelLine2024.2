using Application.CQRSInterfaces;
using Domain.Repository;

namespace Application.UseCases.Like.Command.CreateLike;

public class CreateLikeCommandHanlder : ICommandHandler<CreateLikeCommand>
{
    private readonly ILikeRepository _likeRepository;
    private readonly IUserRepository _userRepository;

    public CreateLikeCommandHanlder( ILikeRepository likeRepository, IUserRepository userRepository )
    {
        _likeRepository = likeRepository;
        _userRepository = userRepository;
    }

    public async Task<Result.Result> HandleAsync( CreateLikeCommand command )
    {
        Domain.Entity.User user = await _userRepository.GetByLogin( command.UserLogin );

        if ( user == null )
        {
            return Result.Result.FromError( "Unknown user" );
        }

        Domain.Entity.Like like = new( user.Id, command.RecipeId );

        if ( await _likeRepository.IsExist( like.UserId, like.RecipeId ) )
        {
            _likeRepository.Remove( like );
        }
        else
        {
            _likeRepository.Add( like );
        }

        return Result.Result.FromSuccess();
    }
}
