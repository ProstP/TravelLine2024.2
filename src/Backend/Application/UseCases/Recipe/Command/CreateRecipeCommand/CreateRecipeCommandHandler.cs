using Application.CQRSInterfaces;
using Application.UnitOfWork;
using Domain.Entity;
using Domain.Repository;

namespace Application.UseCases.Recipe.Command.CreateRecipeCommand;

public class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRecipeCommandHandler( IRecipeRepository recipeRepository, IUnitOfWork unitOfWork )
    {
        _recipeRepository = recipeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result.Result> HandleAsync( CreateRecipeCommand command )
    {
        Domain.Entity.Recipe recipe =
            new( command.Name, command.Description, command.CookingTime, command.PersonNum, command.Image, command.UserId );

        foreach ( CreateIngredientCommand ingredient in command.Ingredients )
        {
            recipe.Ingredients.Add( new Ingredient( ingredient.Header, ingredient.SubIngredients ) );
        }

        foreach ( CreateRecipeStepCommand recipeStep in command.RecipeSteps )
        {
            recipe.Steps.Add( new RecipeStep( recipeStep.StepNum, recipeStep.Description ) );
        }

        _recipeRepository.Add( recipe );
        await _unitOfWork.SaveChangesAsync();

        return Result.Result.FromSuccess();
    }
}
