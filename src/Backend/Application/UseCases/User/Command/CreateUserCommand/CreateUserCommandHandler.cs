using Application.CQRSInterfaces;
using Application.Crypt.HashPassword;
using Application.UnitOfWork;
using Domain.Repository;

namespace Application.UseCases.User.Command.CreateUserCommand;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
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

    public async Task<Result.Result> HandleAsync( CreateUserCommand command )
    {
        try
        {
            Domain.Entity.User userInDb = await _userRepository.GetByLogin( command.Login );
            if ( userInDb != null )
            {
                return Result.Result.FromError( "Login already in use" );
            }

            string passwordHash = _passwordHasher.Hash( command.Password );
            Domain.Entity.User user = new( command.Name, command.Login, passwordHash );

            _userRepository.Add( user );
            await _unitOfWork.SaveChangesAsync();
        }
        catch ( Exception e )
        {
            return Result.Result.FromError( e.Message );
        }
        return Result.Result.FromSuccess();
    }
}
