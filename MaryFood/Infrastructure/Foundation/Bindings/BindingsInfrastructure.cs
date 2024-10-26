using Application.Crypt.HashStr;
using Application.Crypt.VerifyHash;
using Application.Token.CreateToken;
using Application.Token.DecodeToken;
using Application.Token.RefreshTokens;
using Application.UnitOfWork;
using Application.User.Command.AuthenticateUserCommand;
using Application.User.Command.CreateUserCommand;
using Domain.Repository;
using Infrastructure.Foundation.Crypt.HashStr;
using Infrastructure.Foundation.Crypt.VerifyPassword;
using Infrastructure.Foundation.Repository;
using Infrastructure.Foundation.Token.CreateToken;
using Infrastructure.Foundation.Token.DecodeToken;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Foundation.Bindings;
public static class BindingsInfrastructure
{
    public static void Bind( WebApplicationBuilder builder )
    {
        string sqlConnection = builder.Configuration.GetSection( "SqlServerOptions" ).GetSection( "Connection" ).Value;

        builder.Services.AddDbContext<MaryFoodDbContext>( options =>
        {
            options.UseSqlServer( sqlConnection );
        } );

        builder.Services.AddScoped( typeof( IRepository<> ), typeof( Repository<> ) );
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
        builder.Services.AddScoped<ITagRepository, TagRepository>();
        builder.Services.AddScoped<IDefaultTagRepository, DefaultTagRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
        builder.Services.AddScoped<IPasswordVerifier, PasswordVerifier>();
        builder.Services.AddScoped<ITokenCreator, TokenCreator>();
        builder.Services.AddScoped<ITokenDecoder, TokenDecoder>();
        builder.Services.AddScoped<AuthenticateUserCommandHandler>();
        builder.Services.AddScoped<CreateUserCommandHandler>();
        builder.Services.AddScoped<RefreshTokenHandler>();
    }
}
