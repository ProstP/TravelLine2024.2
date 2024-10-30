using Application.UseCases.Token.RefreshTokens;
using Application.UseCases.User.Command.AuthenticateUserCommand;
using Application.UseCases.User.Command.CreateUserCommand;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Bindings
    {
        public static void AddApplicationServices( IServiceCollection serviceCollection )
        {
            serviceCollection.AddScoped<AuthenticateUserCommandHandler>();
            serviceCollection.AddScoped<CreateUserCommandHandler>();
            serviceCollection.AddScoped<RefreshTokenHandler>();
        }
    }
}
