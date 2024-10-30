using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.UseCases.Token.DecodeToken;
using Application.UseCases.Token.Dtos;
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

            ClaimsPrincipal principle = tokenHandler.ValidateToken( token, tokenValidationParams, out SecurityToken securityToken );


            if ( securityToken is JwtSecurityToken jwtSecurityToken && jwtSecurityToken.Header.Alg.Equals( SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase )
                && jwtSecurityToken.ValidTo >= DateTime.UtcNow )
            {
                string loginFromToken = principle.FindFirst( ClaimTypes.NameIdentifier ).Value;

                if ( loginFromToken.IsNullOrEmpty() )
                {
                    return null;
                }

                return new DecodeTokenDto()
                {
                    Login = loginFromToken,
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
