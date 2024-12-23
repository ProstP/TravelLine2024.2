using Application.CQRSInterfaces;
using Application.UnitOfWork;
using Domain.Repository;

namespace Application.UseCases.Recipe.Command.DeleteRecipeCommand;

public class DeleteRecipeCommandHandler : ICommandHandler<DeleteRecipeCommand>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public DeleteRecipeCommandHandler( IRecipeRepository recipeRepository, IUnitOfWork unitOfWork, IUserRepository userRepository )
    {
        _recipeRepository = recipeRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Result.Result> HandleAsync( DeleteRecipeCommand command )
    {
        Domain.Entity.User user = await _userRepository.GetByLogin( command.UserLogin );

        if ( user == null )
        {
            return Result.Result.FromError( "Unknown user" );
        }

        Domain.Entity.Recipe recipe = await _recipeRepository.Get( command.Id );

        if ( recipe != null )
        {
            if ( recipe.UserId != user.Id )
            {
                return Result.Result.FromError( "You can not delete this recipe" );
            }

            _recipeRepository.Remove( recipe );
            await _unitOfWork.SaveChangesAsync();
        }

        return Result.Result.FromSuccess();
    }
}
