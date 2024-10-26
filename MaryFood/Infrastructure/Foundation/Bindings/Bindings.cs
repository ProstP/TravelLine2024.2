using System.Text;
using Application.Crypt.HashStr;
using Application.Crypt.VerifyHash;
using Application.Token.CreateToken;
using Application.Token.DecodeToken;
using Application.UnitOfWork;
using Domain.Repository;
using Infrastructure.Foundation.Crypt.HashStr;
using Infrastructure.Foundation.Crypt.VerifyPassword;
using Infrastructure.Foundation.Repository;
using Infrastructure.Foundation.Token;
using Infrastructure.Foundation.Token.CreateToken;
using Infrastructure.Foundation.Token.DecodeToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Foundation.Bindings;
public static class Bindings
{
    public static void Bind( WebApplicationBuilder builder )
    {
        string sqlConnection = builder.Configuration.GetSection( "SqlServerOptions" ).GetSection( "Connection" ).Value;

        builder.Services.AddDbContext<MaryFoodDbContext>( options =>
        {
            options.UseSqlServer( sqlConnection );
        } );

        IConfigurationSection jwtSection = builder.Configuration.GetSection( "JWTSettings" );
        builder.Services.Configure<JWTSettings>( jwtSection );

        JWTSettings jwtSettings = jwtSection.Get<JWTSettings>();
        byte[] key = Encoding.ASCII.GetBytes( jwtSettings.SecretKey );

        builder.Services.AddAuthentication( x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        } )
            .AddJwtBearer( x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey( key ),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                };
            } );

        builder.Services.AddScoped( typeof( IRepository<> ), typeof( Repository<> ) );
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
        builder.Services.AddScoped<ITagRepository, TagRepository>();
        builder.Services.AddScoped<IDefaultTagRepository, DefaultTagRepository>();
        builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
        builder.Services.AddScoped<IPasswordVerifier, PasswordVerifier>();
        builder.Services.AddScoped<ITokenCreator, TokenCreator>();
        builder.Services.AddScoped<ITokenDecoder, TokenDecoder>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
    }
}
