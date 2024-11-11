using Application.CQRSInterfaces;
using Application.Result;
using Application.UseCases.User.Dtos;
using Domain.Repository;

namespace Application.UseCases.User.Query.GetUserQuery;

public class GetUserQueryHandler : IQueryHanlder<GetUserQueryDto, GetUserQuery>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler( IUserRepository userRepository )
    {
        _userRepository = userRepository;
    }

    public async Task<Result<GetUserQueryDto>> HandleAsync( GetUserQuery query )
    {
        Domain.Entity.User user = await _userRepository.GetByLogin( query.Login );

        if ( user == null )
        {
            return Result<GetUserQueryDto>.FromError( "Unknown user" );
        }

        GetUserQueryDto result = new()
        {
            Name = user.Name,
            Login = user.Login,
            About = user.About,

        };

        return Result<GetUserQueryDto>.FromSuccess( result );
    }
}
