namespace Application.Crypt.HashPassword;
public interface IPasswordHasher
{
    string Hash( string password );
}
