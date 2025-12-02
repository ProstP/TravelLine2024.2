using Application.CQRSInterfaces;
using Application.UnitOfWork;
using Domain.Repository;

namespace Application.UseCases.Like.Command.CreateLike;

public class CreateLikeCommandHanlder : ICommandHandler<CreateLikeCommand>
{
    private readonly ILikeRepository _likeRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateLikeCommandHanlder(
        ILikeRepository likeRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork )
    {
        _likeRepository = likeRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
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

        await _unitOfWork.SaveChangesAsync();

        return Result.Result.FromSuccess();
    }
}
