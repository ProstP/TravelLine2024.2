namespace Domain.Entity
{
    public class MainTag
    {
        public int Id { get; private init; }

        public int TagId { get; private init; }

        public Tag Tag { get; private init; } = null;

        public MainTag( int id, int tagId )
        {
            Id = id;
            TagId = tagId;
        }
    }
}
