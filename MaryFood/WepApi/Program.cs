using Application;
using Infrastructure.Foundation;
using WebApi;

WebApplicationBuilder builder = WebApplication.CreateBuilder( args );

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddConfiguration( builder.Configuration );

builder.Services
    .AddInfrastructureServices()
    .AddApplicationServices()
    .AddWebApiServices();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
