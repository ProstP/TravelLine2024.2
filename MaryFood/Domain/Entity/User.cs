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
        if ( String.IsNullOrWhiteSpace( login ) )
        {
            throw new ArgumentNullException( "Invalid login", nameof( login ) );
        }
        Login = login;
        if ( String.IsNullOrWhiteSpace( passwordHash ) )
        {
            throw new ArgumentNullException( "Invalid passwordHash", nameof( passwordHash ) );
        }
        PasswordHash = passwordHash;
    }


    public void Update( string login, string passwordHash, string name, string about )
    {
        if ( String.IsNullOrWhiteSpace( login ) )
        {
            throw new ArgumentNullException( "Invalid login", nameof( login ) );
        }
        Login = login;
        if ( String.IsNullOrWhiteSpace( passwordHash ) )
        {
            throw new ArgumentNullException( "Invalid passwordHash", nameof( passwordHash ) );
        }
        PasswordHash = passwordHash;
        if ( String.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentNullException( "Invalid name", nameof( name ) );
        }
        Name = name;
        About = about;
    }
}
