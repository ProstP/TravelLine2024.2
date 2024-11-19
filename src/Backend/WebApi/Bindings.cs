using System.Text;
using Infrastructure.Foundation.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.Options;

namespace WebApi;

public static class Bindings
{
    public static IServiceCollection AddConfiguration( this IServiceCollection serviceCollection, IConfiguration configuration )
    {
        serviceCollection.Configure<JWTSettings>( configuration.GetSection( "JWTSettings" ) );
        serviceCollection.Configure<DbSettings>( configuration.GetSection( "DbSettings" ) );
        serviceCollection.Configure<FrontendSettings>( configuration.GetSection( "FrontendSettings" ) );

        return serviceCollection;
    }

    public static IServiceCollection AddWebApiServices( this IServiceCollection serviceCollection, IConfiguration configuration )
    {
        string secretKey = configuration.GetSection( "JWTSettings" ).GetSection( "SecretKey" ).Value;
        byte[] key = Encoding.ASCII.GetBytes( secretKey );

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

        string frontendUrl = configuration.GetSection( "FrontendSettings" ).GetSection( "Url" ).Value;
        serviceCollection.AddCors( options =>
        {
            options.AddPolicy( "AllowSpecificOrigin",
                policy => policy.WithOrigins( frontendUrl! )
                                  .AllowAnyMethod()
                                  .AllowAnyHeader() );
        } );

        return serviceCollection;
    }
}
