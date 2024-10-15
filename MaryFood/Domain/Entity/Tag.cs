namespace Domain.Entity
{
    public class Tag
    {
        public int Id { get; private init; }
        public string Name { get; private init; }
        public string Description { get; private init; }

        public List<Recipe> Recipes { get; private init; } = new();

        public Tag( int id, string name, string description )
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
