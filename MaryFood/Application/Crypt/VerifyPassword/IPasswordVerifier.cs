namespace Application.Crypt.VerifyHash;
public interface IPasswordVerifier
{
    bool Verify( string password, string hash );
}
