using Application.CQRSInterfaces;
using Application.Crypt.HashPassword;
using Application.Result;
using Application.UnitOfWork;
using Application.UseCases.Token.CreateToken;
using Application.UseCases.User.Dtos;
using Domain.Repository;

namespace Application.UseCases.User.Command.UpdateUserCommand;

public class UpdateUserCommandHandler : ICommandHandler<UpdateUserDto, UpdateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenCreator _tokenCreator;

    public UpdateUserCommandHandler( IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, ITokenCreator tokenCreator )
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _tokenCreator = tokenCreator;
    }

    public async Task<Result<UpdateUserDto>> HandleAsync( UpdateUserCommand command )
    {
        Domain.Entity.User user = await _userRepository.GetByLogin( command.OldLogin );

        if ( user == null )
        {
            return Result.Result<UpdateUserDto>.FromError( "Unknown user" );
        }

        string login = string.IsNullOrWhiteSpace( command.Login ) ? user.Login : command.Login;
        string passwordHash = string.IsNullOrWhiteSpace( command.Password ) ? user.PasswordHash : _passwordHasher.Hash( command.Password );
        string name = string.IsNullOrWhiteSpace( command.Name ) ? user.Name : command.Name;
        string about = string.IsNullOrWhiteSpace( command.About ) ? user.About : command.About;

        user.Update( login, passwordHash, name, about );

        if ( _userRepository.Update( user.Id, user ) == null )
        {
            return Result<UpdateUserDto>.FromError( "Error in save" );
        }

        await _unitOfWork.SaveChangesAsync();

        UpdateUserDto updateUserDto = new()
        {
            AccessToken = _tokenCreator.GenerateAccessToken( user.Login ),
            RefreshToken = _tokenCreator.GenerateRefreshToken( user.Login )
        };

        return Result<UpdateUserDto>.FromSuccess( updateUserDto );
    }
}
