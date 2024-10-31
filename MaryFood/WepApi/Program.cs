WebApplicationBuilder builder = WebApplication.CreateBuilder( args );

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Bindings.AddConfiguration( builder.Services, builder.Configuration );
Infrastructure.Foundation.Bindings.AddInfrastructureServices( builder.Services );
Application.Bindings.AddApplicationServices( builder.Services );
Bindings.AdddWebApiServices( builder.Services );

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
