using System.Text;
using Domain.Entity;
using Domain.Repository;
using Infrastructure.Foundation;
using Infrastructure.Foundation.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MaryFoodDbContext>( options =>
{
    options.UseSqlServer( "Server=LAPTOP-U0R8E398\\SQLEXPRESS;Database=MaryFood;Trusted_Connection=True;TrustServerCertificate=True;" );
} );

builder.Services.AddScoped( typeof( IRepository<> ), typeof( Repository<> ) );
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IDefaultTagRepository, DefaultTagRepository>();

var jwtSection = builder.Configuration.GetSection( "JWTSettings" );
builder.Services.Configure<JWTSettings>( jwtSection );

var appSettings = jwtSection.Get<JWTSettings>();
var key = Encoding.ASCII.GetBytes( appSettings.SecretKey );

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

var app = builder.Build();

if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
