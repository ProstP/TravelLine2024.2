using System.Text;
using Infrastructure.Foundation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace WebApi;

public static class Bindings
{
    public static IServiceCollection AddConfiguration( this IServiceCollection serviceCollection, IConfiguration configuration )
    {
        serviceCollection.Configure<JWTSettings>( configuration.GetSection( "JWTSettings" ) );
        serviceCollection.Configure<DbSettings>( configuration.GetSection( "DbSettings" ) );

        return serviceCollection;
    }

    public static IServiceCollection AddWebApiServices( this IServiceCollection serviceCollection )
    {
        JWTSettings jwtSettings = serviceCollection.BuildServiceProvider().GetRequiredService<IOptions<JWTSettings>>().Value;
        byte[] key = Encoding.ASCII.GetBytes( jwtSettings.SecretKey );

        serviceCollection.AddAuthentication( x =>
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

        return serviceCollection;
    }
}
