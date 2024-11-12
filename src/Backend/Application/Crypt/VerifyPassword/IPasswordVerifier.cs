namespace Application.Crypt.VerifyPassword;
public interface IPasswordVerifier
{
    bool Verify( string password, string hash );
}
