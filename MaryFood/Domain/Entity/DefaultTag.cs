namespace Domain.Entity
{
    public class DefaultTag
    {
        public int Id { get; private init; }

        public int TagId { get; private init; }

        public DefaultTag( int id, int tagId )
        {
            Id = id;
            TagId = tagId;
        }
    }
}
