﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.UseCases.Token.CreateToken;
using Infrastructure.Foundation.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Foundation.Token.CreateToken;

public class TokenCreator : ITokenCreator
{
    private readonly JWTSettings _jwtSettings;

    public TokenCreator( IOptions<JWTSettings> jwtSettings )
    {
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateAccessToken( string login )
    {
        return GenerateToken( login, TimeSpan.FromMinutes( 15 ) );
    }

    public string GenerateRefreshToken( string login )
    {
        return GenerateToken( login, TimeSpan.FromDays( 1 ) );
    }

    private string GenerateToken( string login, TimeSpan lifeTime )
    {
        JwtSecurityTokenHandler tokenHandler = new();
        byte[] key = Encoding.ASCII.GetBytes( _jwtSettings.SecretKey );
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.NameIdentifier, login),
            ] ),
            Expires = DateTime.UtcNow.Add(lifeTime),
            SigningCredentials = new SigningCredentials( new SymmetricSecurityKey( key ), SecurityAlgorithms.HmacSha256Signature )

        };
        SecurityToken token = tokenHandler.CreateToken( tokenDescriptor );

        return tokenHandler.WriteToken( token );
    }
}
