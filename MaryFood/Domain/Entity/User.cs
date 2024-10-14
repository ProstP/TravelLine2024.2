namespace Domain.Entity
{
    public class User
    {
        public int Id { get; private init; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public string About { get; private set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public List<Recipe> Recipes { get; private init; } = new();

        [System.Text.Json.Serialization.JsonIgnore]
        public List<Favourite> Favourite { get; private init; } = new();

        [System.Text.Json.Serialization.JsonIgnore]
        public List<Like> Like { get; private init; } = new();

        public User( int id, string login, string password, string name, string about )
        {
            Id = id;
            if ( String.IsNullOrWhiteSpace( login ) )
            {
                throw new ArgumentNullException( "Login is empty or white space" );
            }
            Login = login;
            Password = password;
            if ( String.IsNullOrWhiteSpace( name ) )
            {
                throw new ArgumentNullException( "Name is empty or white space" );
            }
            Name = name;
            About = about;
        }


        public void Update( string login, string password, string name, string about )
        {
            if ( String.IsNullOrWhiteSpace( login ) )
            {
                throw new ArgumentNullException( "Login is empty or white space" );
            }
            Login = login;
            Password = password;
            if ( String.IsNullOrWhiteSpace( name ) )
            {
                throw new ArgumentNullException( "Name is empty or white space" );
            }
            Name = name;
            About = about;
        }
    }
}
