using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Tokens.Dtos;
using Domain.Entity;
using Domain.Repository;
using Microsoft.IdentityModel.Tokens;

namespace Application.Tokens.DecodeToken
{
    public class RefreshTokenDecoder
    {
        private readonly JWTSettings _jwtSettings;

        public RefreshTokenDecoder( JWTSettings jwtSettings, IUserRepository userRepository )
        {
            _jwtSettings = jwtSettings;
        }

        public DecodeTokenDto Decode( string token )
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes( _jwtSettings.SecretKey );

                var tokenValidationParams = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey( key ),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                };

                SecurityToken securityToken;
                var principle = tokenHandler.ValidateToken( token, tokenValidationParams, out securityToken );

                JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;

                if ( jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals( SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase )
                    && jwtSecurityToken.ValidTo >= DateTime.UtcNow )
                {
                    var tokenType = principle.FindFirst( "type" ).Value;
                    if ( tokenType != "refresh" )
                    {
                        return null;
                    }

                    var loginFromToken = principle.FindFirst( ClaimTypes.NameIdentifier ).Value;
                    var passFromToken = principle.FindFirst( "password" ).Value;

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
}
