using System.Text;
using Infrastructure.Foundation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

public static class Bindings
{
    public static void AddConfiguration( ConfigurationManager configurationManager )
    {
        JWTSettings jwtSettings = new();
        configurationManager.GetSection( "JWTSettings" ).Bind( jwtSettings );

        DbSettings dbOptions = new();
        configurationManager.GetSection( "DbSettings" ).Bind( dbOptions );
    }

    public static void AdddWebApiServices( IServiceCollection serviceCollection )
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

    }
}
