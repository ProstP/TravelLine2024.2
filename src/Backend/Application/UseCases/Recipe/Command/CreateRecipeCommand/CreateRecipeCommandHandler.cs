﻿using Application.CQRSInterfaces;
using Application.UnitOfWork;
using Domain.Entity;
using Domain.Repository;

namespace Application.UseCases.Recipe.Command.CreateRecipeCommand;

public class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITagRepository _tagRepository;
    private readonly IUserRepository _userRepository;

    public CreateRecipeCommandHandler(
        IRecipeRepository recipeRepository,
        IUnitOfWork unitOfWork,
        ITagRepository tagRepository,
        IUserRepository userRepository )
    {
        _recipeRepository = recipeRepository;
        _unitOfWork = unitOfWork;
        _tagRepository = tagRepository;
        _userRepository = userRepository;
    }

    public async Task<Result.Result> HandleAsync( CreateRecipeCommand command )
    {
        Domain.Entity.User user = await _userRepository.GetByLogin( command.UserLogin );

        if ( user == null )
        {
            return Result.Result.FromError( "Unknown user" );
        }

        Domain.Entity.Recipe recipe =
            new( command.Name, command.Description, command.CookingTime, command.PersonNum, command.Image, command.CreatedDate, user.Id );

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

        recipe.Ingredients.AddRange( command.Ingredients
                .Select( i =>
                new Ingredient( i.Header, i.SubIngredients ) ).ToList() );

        recipe.Steps.AddRange( command.RecipeSteps
                .Select( rs =>
                new RecipeStep( rs.StepNum, rs.Description ) ).ToList() );

        _recipeRepository.Add( recipe );
        await _unitOfWork.SaveChangesAsync();

        return Result.Result.FromSuccess();
    }
}
