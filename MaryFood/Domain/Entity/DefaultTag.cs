namespace Domain.Entity;

public class DefaultTag : Entity
{

    public int TagId { get; private init; }

    public DefaultTag( int tagId )
    {
        TagId = tagId;
    }
}
