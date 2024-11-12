using Application.Crypt.HashPassword;

namespace Infrastructure.Foundation.Crypt.HashPassword;
public class PasswordHasher : IPasswordHasher
{
    public string Hash( string password )
    {
        return BCrypt.Net.BCrypt.HashPassword( password );
    }
}