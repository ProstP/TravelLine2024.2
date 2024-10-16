namespace Domain.Entity
{
    public class Favourite
    {
        public int UserId { get; private init; }
        public int RecipeId { get; private init; }

        public Favourite( int userId, int recipeId )
        {
            UserId = userId;
            RecipeId = recipeId;
        }
    }
}
