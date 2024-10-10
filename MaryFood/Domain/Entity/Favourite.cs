namespace Domain.Entity
{
    public class Favourite
    {
        public int Id { get; private init; }

        public int UserId { get; private init; }
        public int RecipeId { get; private init; }

        public Favourite( int id, int userId, int recipeId )
        {
            Id = id;
            UserId = userId;
            RecipeId = recipeId;
        }
    }
}
