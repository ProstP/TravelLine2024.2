using Application.Crypt.VerifyHash;

namespace Infrastructure.Foundation.Crypt.VerifyPassword;
public class PasswordVefifier : IPasswordVerifier
{
    public bool Verify( string password, string hash )
    {
        return BCrypt.Net.BCrypt.Verify( password, hash );
    }
}
