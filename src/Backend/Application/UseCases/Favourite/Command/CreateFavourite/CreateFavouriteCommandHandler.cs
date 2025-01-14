using Application.CQRSInterfaces;
using Application.UnitOfWork;
using Domain.Repository;

namespace Application.UseCases.Favourite.Command.CreateFavourite;

public class CreateFavouriteCommandHandler : ICommandHandler<CreateFavouriteCommand>
{
    private readonly IFavouriteRepository _favouriteRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFavouriteCommandHandler(
        IFavouriteRepository favouriteRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork )
    {
        _favouriteRepository = favouriteRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result.Result> HandleAsync( CreateFavouriteCommand command )
    {
        Domain.Entity.User user = await _userRepository.GetByLogin( command.UserLogin );

        if ( user == null )
        {
            return Result.Result.FromError( "Unknown user" );
        }

        Domain.Entity.Favourite favourite = new( user.Id, command.RecipeId );

        if ( await _favouriteRepository.IsExist( favourite.UserId, favourite.RecipeId ) )
        {
            _favouriteRepository.Remove( favourite );
        }
        else
        {
            _favouriteRepository.Add( favourite );
        }

        await _unitOfWork.SaveChangesAsync();

        return Result.Result.FromSuccess();
    }
}
