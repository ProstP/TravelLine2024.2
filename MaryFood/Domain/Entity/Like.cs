namespace Domain.Entity
{
    public class Like
    {
        public int UserId { get; private init; }
        public int RecipeId { get; private init; }

        public Like( int userId, int recipeId )
        {
            UserId = userId;
            RecipeId = recipeId;
        }
    }
}
