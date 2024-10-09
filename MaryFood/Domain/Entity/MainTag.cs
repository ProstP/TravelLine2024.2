namespace Domain.Entity
{
    public class MainTag
    {
        public int Id { get; private init; }

        public int TagId { get; private init; }

        public MainTag( int id, int tagId )
        {
            Id = id;
            TagId = tagId;
        }
    }
}
