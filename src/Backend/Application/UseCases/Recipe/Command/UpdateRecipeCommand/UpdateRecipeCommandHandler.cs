using Application.CQRSInterfaces;
using Application.ImageStore.DeleteImage;
using Application.ImageStore.SaveImage;
using Application.UnitOfWork;
using Domain.Entity;
using Domain.Repository;

namespace Application.UseCases.Recipe.Command.UpdateRecipeCommand;

public class UpdateRecipeCommandHandler : ICommandHandler<UpdateRecipeCommand>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITagRepository _tagRepository;
    private readonly IUserRepository _userRepository;
    private readonly IImageSaver _imageSaver;
    private readonly IImageDeleter _imageDeleter;

    public UpdateRecipeCommandHandler(
        IRecipeRepository recipeRepository,
        IUnitOfWork unitOfWork,
        ITagRepository tagRepository,
        IUserRepository userRepository,
        IImageSaver imageSaver,
        IImageDeleter imageDeleter )
    {
        _recipeRepository = recipeRepository;
        _unitOfWork = unitOfWork;
        _tagRepository = tagRepository;
        _userRepository = userRepository;
        _imageSaver = imageSaver;
        _imageDeleter = imageDeleter;
    }

    public async Task<Result.Result> HandleAsync( UpdateRecipeCommand command )
    {
        try
        {
            Domain.Entity.User user = await _userRepository.GetByLogin( command.UserLogin );

            if ( user == null )
            {
                return Result.Result.FromError( "Uknown user" );
            }

            Domain.Entity.Recipe recipe = await _recipeRepository.Get( command.Id );

            if ( recipe == null )
            {
                return Result.Result.FromError( "Unknown recipe" );
            }

            if ( recipe.UserId != user.Id )
            {
                return Result.Result.FromError( "You can not delete this recipe" );
            }

            _imageDeleter.Delete( recipe.Image );
            string path = _imageSaver.Save( command.Image );
            recipe.Update( command.Name, command.Description, command.CookingTime, command.PersonNum, path );

            recipe.Tags.Clear();
            command.Tags.ForEach( name =>
            {
                Tag tag = _tagRepository.GetByName( name );

                if ( tag == null )
                {
                    recipe.Tags.Add( new( name ) );
                }
                else
                {
                    recipe.Tags.Add( tag );
                }
            } );

            List<int> ingredientsToRemove = [];
            for ( int i = 0; i < recipe.Ingredients.Count; i++ )
            {
                if ( !command.Ingredients.Any( elt => elt.Id == recipe.Ingredients[ i ].Id ) )
                {
                    ingredientsToRemove.Add( i );
                }
            }
            foreach ( int index in ingredientsToRemove )
            {
                recipe.Ingredients.RemoveAt( index );
            }
            foreach ( UpdateIngredientCommand update in command.Ingredients )
            {
                if ( update.Id == 0 )
                {
                    recipe.Ingredients.Add( new( update.Header, update.SubIngredients ) );
                }
                else
                {
                    Ingredient ingredient = recipe.Ingredients.FirstOrDefault( i => i.Id == update.Id );
                    if ( ingredient == null )
                    {
                        recipe.Ingredients.Add( new( update.Header, update.SubIngredients ) );
                    }
                    else
                    {
                        ingredient.Update( update.Header, update.SubIngredients );
                    }
                }
            }

            List<int> stepsToRemove = [];
            for ( int i = 0; i < recipe.Steps.Count; i++ )
            {
                if ( !command.RecipeSteps.Any( elt => elt.Id == recipe.Steps[ i ].Id ) )
                {
                    stepsToRemove.Add( i );
                }
            }
            foreach ( int index in stepsToRemove )
            {
                recipe.Steps.RemoveAt( index );
            }
            foreach ( UpdateRecipeStepCommand update in command.RecipeSteps )
            {
                if ( update.Id == 0 )
                {
                    recipe.Steps.Add( new( update.StepNum, update.Description ) );
                }
                else
                {
                    RecipeStep recipeStep = recipe.Steps.FirstOrDefault( i => i.Id == update.Id );
                    if ( recipeStep == null )
                    {
                        recipe.Steps.Add( new( update.StepNum, update.Description ) );
                    }
                    else
                    {
                        recipeStep.Update( update.StepNum, update.Description );
                    }
                }
            }

            _recipeRepository.Update( command.Id, recipe );
            await _unitOfWork.SaveChangesAsync();
        }
        catch ( Exception e )
        {
            return Result.Result.FromError( e.Message );
        }

        return Result.Result.FromSuccess();
    }
}
