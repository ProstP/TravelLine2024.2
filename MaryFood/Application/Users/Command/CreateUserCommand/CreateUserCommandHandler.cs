using Application.UnitOfWork;
using Domain.Entity;
using Domain.Repository;

namespace Application.Users.Command.CreateUserCommand;

public class CreateUserCommandHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler( IUserRepository userRepository, IUnitOfWork unitOfWork )
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public bool Handle( CreateUserCommand command )
    {
        try
        {
            User user = new( command.Login, command.PasswordHash );

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
