namespace Domain.Entity
{
    public class Like
    {
        public int Id { get; private init; }

        public int UserId { get; private init; }
        public int RecipeId { get; private init; }

        public Like( int id, int userId, int recipeId )
        {
            Id = id;
            UserId = userId;
            RecipeId = recipeId;
        }
    }
}
