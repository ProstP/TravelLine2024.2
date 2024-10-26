using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Token.DecodeToken;
using Application.Token.Dtos;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Foundation.Token.DecodeToken;

public class TokenDecoder : ITokenDecoder
{
    private readonly JWTSettings _jwtSettings;

    public TokenDecoder( IOptions<JWTSettings> jwtSettings )
    {
        _jwtSettings = jwtSettings.Value;
    }

    public DecodeTokenDto Decode( string token )
    {
        try
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes( _jwtSettings.SecretKey );

            TokenValidationParameters tokenValidationParams = new()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey( key ),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
            };

            SecurityToken securityToken;
            ClaimsPrincipal principle = tokenHandler.ValidateToken( token, tokenValidationParams, out securityToken );

            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;

            if ( jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals( SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase )
                && jwtSecurityToken.ValidTo >= DateTime.UtcNow )
            {
                string loginFromToken = principle.FindFirst( ClaimTypes.NameIdentifier ).Value;
                string passFromToken = principle.FindFirst( "password" ).Value;

                if ( loginFromToken.IsNullOrEmpty() || passFromToken.IsNullOrEmpty() )
                {
                    return null;
                }

                return new DecodeTokenDto()
                {
                    Login = loginFromToken,
                    PasswordHash = passFromToken,
                };
            }
        }
        catch ( Exception )
        {
            return null;
        }

        return null;
    }
}
