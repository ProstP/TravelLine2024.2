using Application.UseCases.Like.Command.CreateLike;
using Application.UseCases.Like.Query.IsUserSetLike;
using Application.UseCases.Recipe.Command.CreateRecipeCommand;
using Application.UseCases.Recipe.Command.DeleteRecipeCommand;
using Application.UseCases.Recipe.Command.UpdateRecipeCommand;
using Application.UseCases.Recipe.Query.GetRecipeListByUserQuery;
using Application.UseCases.Recipe.Query.GetRecipeListQuery;
using Application.UseCases.Recipe.Query.GetRecipeQuery;
using Application.UseCases.Token.RefreshTokens;
using Application.UseCases.User.Command.AuthenticateByTokenCommand;
using Application.UseCases.User.Command.AuthenticateUserCommand;
using Application.UseCases.User.Command.CreateUserCommand;
using Application.UseCases.User.Command.UpdateUserCommand;
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
            serviceCollection.AddScoped<UpdateUserCommandHandler>();
            serviceCollection.AddScoped<RefreshTokenHandler>();
            serviceCollection.AddScoped<GetUserQueryHandler>();
            serviceCollection.AddScoped<RefreshTokenHandler>();
            serviceCollection.AddScoped<CreateRecipeCommandHandler>();
            serviceCollection.AddScoped<GetRecipeQueryHandler>();
            serviceCollection.AddScoped<DeleteRecipeCommandHandler>();
            serviceCollection.AddScoped<UpdateRecipeCommandHandler>();
            serviceCollection.AddScoped<AuthenticateByTokenCommandHandler>();
            serviceCollection.AddScoped<GetRecipeListQueryHandler>();
            serviceCollection.AddScoped<GetRecipeListByUserQueryHandler>();
            serviceCollection.AddScoped<CreateLikeCommandHanlder>();
            serviceCollection.AddScoped<IsUserSetLikeQueryHandler>();

            return serviceCollection;
        }
    }
}
