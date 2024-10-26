using Application.CQRSInterfaces;
using Application.Crypt.HashStr;
using Application.Result;
using Application.UnitOfWork;
using Domain.Entity;
using Domain.Repository;

namespace Application.Users.Command.CreateUserCommand;

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
            string passwordHash = _passwordHasher.Hash( command.Password );
            User user = new( command.Login, passwordHash );

            _userRepository.Add( user );
            await _unitOfWork.SaveChangesAsync();
        }
        catch
        {
            return Result.Result.FromError( "User not created" );
        }
        return Result.Result.FromSuccess();
    }
}
