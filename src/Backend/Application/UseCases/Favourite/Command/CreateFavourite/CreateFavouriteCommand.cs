namespace Application.UseCases.Favourite.Command.CreateFavourite;

public class CreateFavouriteCommand
{
    public string UserLogin { get; init; }
    public int RecipeId { get; init; }
}
