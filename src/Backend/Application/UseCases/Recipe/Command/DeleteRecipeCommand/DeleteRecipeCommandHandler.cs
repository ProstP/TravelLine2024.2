using Application.CQRSInterfaces;
using Application.UnitOfWork;
using Domain.Repository;

namespace Application.UseCases.Recipe.Command.DeleteRecipeCommand;

public class DeleteRecipeCommandHandler : ICommandHandler<DeleteRecipeCommand>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRecipeCommandHandler( IRecipeRepository recipeRepository, IUnitOfWork unitOfWork )
    {
        _recipeRepository = recipeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result.Result> HandleAsync( DeleteRecipeCommand command )
    {
        Domain.Entity.Recipe recipe = await _recipeRepository.Get( command.Id );

        if ( recipe != null )
        {
            _recipeRepository.Remove( recipe );
            await _unitOfWork.SaveChangesAsync();
        }

        return Result.Result.FromSuccess();
    }
}
