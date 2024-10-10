namespace Domain.Entity
{
    public class User
    {
        public int Id { get; private init; }
        public string Login { get; private init; }
        public string Password { get; private init; }
        public string Name { get; private init; }
        public string About { get; private init; }

        [System.Text.Json.Serialization.JsonIgnore]
        public List<Recipe> Recipes { get; private init; } = new();

        [System.Text.Json.Serialization.JsonIgnore]
        public List<Favourite> Favourite { get; private init; } = new();

        [System.Text.Json.Serialization.JsonIgnore]
        public List<Like> Like { get; private init; } = new();

        public User( int id, string login, string password, string name, string about )
        {
            Id = id;
            Login = login;
            Password = password;
            Name = name;
            About = about;
        }
    }
}
