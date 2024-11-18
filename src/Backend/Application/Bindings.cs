using Application.UseCases.Recipe.Command.CreateRecipeCommand;
using Application.UseCases.Recipe.Query.GetRecipeQuery;
using Application.UseCases.Token.RefreshTokens;
using Application.UseCases.User.Command.AuthenticateUserCommand;
using Application.UseCases.User.Command.CreateUserCommand;
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
            serviceCollection.AddScoped<CreateRecipeCommandHandler>();
            serviceCollection.AddScoped<GetRecipeQueryHandler>();

            return serviceCollection;
        }
    }
}
