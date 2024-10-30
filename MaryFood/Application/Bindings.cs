using Application.Token.RefreshTokens;
using Application.User.Command.AuthenticateUserCommand;
using Application.User.Command.CreateUserCommand;
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
