namespace Application.Crypt.HashStr;
public interface IPasswordHasher
{
    string Hash( string password );
}
