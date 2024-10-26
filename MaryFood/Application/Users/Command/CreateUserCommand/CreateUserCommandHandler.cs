using Application.Crypt.HashStr;
using Application.UnitOfWork;
using Domain.Entity;
using Domain.Repository;

namespace Application.Users.Command.CreateUserCommand;

public class CreateUserCommandHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;

    public CreateUserCommandHandler( IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher )
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public bool Handle( CreateUserCommand command )
    {
        try
        {
            string passwordHash = _passwordHasher.Hash( command.Password );
            User user = new( command.Login, passwordHash );

            _userRepository.Add( user );
            _unitOfWork.SaveChangesAsync();
        }
        catch
        {
            return false;
        }
        return true;
    }
}
