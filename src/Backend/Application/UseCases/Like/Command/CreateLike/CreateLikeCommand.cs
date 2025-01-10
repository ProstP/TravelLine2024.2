namespace Application.UseCases.Like.Command.CreateLike;

public class CreateLikeCommand
{
    public string UserLogin { get; init; }
    public int RecipeId { get; init; }
}
