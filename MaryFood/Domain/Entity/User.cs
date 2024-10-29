namespace Domain.Entity;

public class User : Entity
{
    public string Login { get; private set; }
    public string PasswordHash { get; private set; }
    public string Name { get; private set; }
    public string About { get; private set; }

    public List<Favourite> Favourite { get; private init; } = new();
    public List<Like> Like { get; private init; } = new();

    public User( string login, string passwordHash )
    {
        if ( string.IsNullOrWhiteSpace( login ) )
        {
            throw new ArgumentNullException( nameof( login ), "Invalid login" );
        }
        Login = login;
        if ( string.IsNullOrWhiteSpace( passwordHash ) )
        {
            throw new ArgumentNullException( nameof( passwordHash ), "Invalid passwordHash" );
        }
        PasswordHash = passwordHash;
    }


    public void Update( string login, string passwordHash, string name, string about )
    {
        if ( string.IsNullOrWhiteSpace( login ) )
        {
            throw new ArgumentNullException( nameof( login ), "Invalid login" );
        }
        Login = login;
        if ( string.IsNullOrWhiteSpace( passwordHash ) )
        {
            throw new ArgumentNullException( nameof( passwordHash ), "Invalid passwordHash" );
        }
        PasswordHash = passwordHash;
        Name = name;
        About = about;
    }
}
