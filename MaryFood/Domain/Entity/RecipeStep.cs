namespace Domain.Entity
{
    public class RecipeStep
    {
        public int Id { get; private init; }
        public int StepNum { get; private init; }
        public string Description { get; private init; }

        public int RecipeId { get; private init; }

        public RecipeStep( int id, int stepNum, string description, int recipeId )
        {
            Id = id;
            StepNum = stepNum;
            Description = description;
            RecipeId = recipeId;
        }
    }
}
