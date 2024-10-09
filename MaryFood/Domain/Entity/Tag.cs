namespace Domain.Entity
{
    public class Tag
    {
        public int Id { get; private init; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Tag( int id, string name, string description )
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
