namespace Domain.Entity
{
    public class RecipeStep
    {
        public int Id { get; private init; }
        public int StepNum { get; private set; }
        public string Description { get; private set; }

        public int RecipeId { get; private init; }

        public RecipeStep( int id, int stepNum, string description, int recipeId )
        {
            Id = id;
            StepNum = stepNum;
            if ( String.IsNullOrWhiteSpace( description ) )
            {
                throw new ArgumentNullException( "Description is empty or white space" );
            }
            Description = description;
            RecipeId = recipeId;
        }

        public void Update( int stepNum, string description )
        {
            StepNum = stepNum;
            if ( String.IsNullOrWhiteSpace( description ) )
            {
                throw new ArgumentNullException( "Description is empty or white space" );
            }

        }
    }
}
