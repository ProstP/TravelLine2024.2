using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entity;
using Microsoft.IdentityModel.Tokens;

namespace Application.Token.CreateToken;

public class TokenCreator : ITokenCreator
{
    private readonly JWTSettings _jwtSettings;

    public TokenCreator( JWTSettings jwtSettings )
    {
        _jwtSettings = jwtSettings;
    }

    public string GenerateAccessToken( string login )
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes( _jwtSettings.SecretKey );
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.NameIdentifier, login),
            ] ),
            Expires = DateTime.UtcNow.AddMinutes( 15 ),
            SigningCredentials = new SigningCredentials( new SymmetricSecurityKey( key ), SecurityAlgorithms.HmacSha256Signature )

        };
        var token = tokenHandler.CreateToken( tokenDescriptor );

        return tokenHandler.WriteToken( token );
    }

    public string GenerateRefreshToken( string login, string passwordHash )
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes( _jwtSettings.SecretKey );
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.NameIdentifier, login),
            ] ),

            Claims = new Dictionary<string, object>()
            {
                { "password", passwordHash }
            },
            Expires = DateTime.UtcNow.AddDays( 1 ),
            SigningCredentials = new SigningCredentials( new SymmetricSecurityKey( key ), SecurityAlgorithms.HmacSha256Signature )

        };
        var token = tokenHandler.CreateToken( tokenDescriptor );

        return tokenHandler.WriteToken( token );
    }
}
