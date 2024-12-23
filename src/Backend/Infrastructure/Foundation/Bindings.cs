﻿using Application.Crypt.HashPassword;
using Application.Crypt.VerifyPassword;
using Application.UnitOfWork;
using Application.UseCases.Token.CreateToken;
using Application.UseCases.Token.DecodeToken;
using Domain.Repository;
using Infrastructure.Foundation.Crypt.HashPassword;
using Infrastructure.Foundation.Crypt.VerifyPassword;
using Infrastructure.Foundation.Options;
using Infrastructure.Foundation.Repository;
using Infrastructure.Foundation.Token.CreateToken;
using Infrastructure.Foundation.Token.DecodeToken;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure.Foundation;
public static class Bindings
{
    public static IServiceCollection AddInfrastructureServices( this IServiceCollection serviceCollection )
    {
        serviceCollection.AddDbContext<MaryFoodDbContext>( ( serviceProvider, options ) =>
        {
            DbSettings dbSettings = serviceProvider.GetRequiredService<IOptions<DbSettings>>().Value;

            options.UseSqlServer( dbSettings.ConnectionString );
        } );

        serviceCollection.AddScoped( typeof( IRepository<> ), typeof( Repository<> ) );
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IRecipeRepository, RecipeRepository>();
        serviceCollection.AddScoped<ITagRepository, TagRepository>();
        serviceCollection.AddScoped<IDefaultTagRepository, DefaultTagRepository>();
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        serviceCollection.AddScoped<IPasswordHasher, PasswordHasher>();
        serviceCollection.AddScoped<IPasswordVerifier, PasswordVerifier>();
        serviceCollection.AddScoped<ITokenCreator, TokenCreator>();
        serviceCollection.AddScoped<ITokenDecoder, TokenDecoder>();

        return serviceCollection;
    }
}
