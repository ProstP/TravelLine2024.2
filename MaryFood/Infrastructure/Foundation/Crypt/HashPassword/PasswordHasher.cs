using Application.Crypt.HashStr;

namespace Infrastructure.Foundation.Crypt.HashStr;
public class PasswordHasher : IPasswordHasher
{
    public string Hash( string password )
    {
        return BCrypt.Net.BCrypt.HashPassword( password );
    }
}