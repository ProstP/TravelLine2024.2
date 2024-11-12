﻿using Application.UseCases.Token.RefreshTokens;
using Application.UseCases.User.Command.AuthenticateUserCommand;
using Application.UseCases.User.Command.CreateUserCommand;
using Application.UseCases.User.Query.GetUserQuery;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Bindings
    {
        public static IServiceCollection AddApplicationServices( this IServiceCollection serviceCollection )
        {
            serviceCollection.AddScoped<AuthenticateUserCommandHandler>();
            serviceCollection.AddScoped<CreateUserCommandHandler>();
            serviceCollection.AddScoped<RefreshTokenHandler>();
            serviceCollection.AddScoped<GetUserQueryHandler>();

            return serviceCollection;
        }
    }
}