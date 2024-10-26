using System.Text;
using Infrastructure.Foundation.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Foundation.Bindings;
public static class BindingsWebApi
{
    public static void Bind( WebApplicationBuilder builder )
    {
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

    }
}
