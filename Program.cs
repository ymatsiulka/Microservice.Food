using Microservice.Food.Extensions;
using Microservice.Food.Modules;
using Microservice.Food.Modules.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var modules = new IModule[]
{
    new ApiModule(),
    new PersistenceModule(),
    new CoreModule(),
};

foreach (var module in modules)
    module.RegisterDependencies(builder);

var configuration = builder.Configuration;

var app = builder.Build();
app.ApplyMigrations();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/rest/swagger.json", "REST API");
});

app.UseCors(policy =>
{
    var corsOrigins = configuration
        .GetSection("AllowedCorsOrigins")
        .Get<string[]>();

    if (corsOrigins is not null)
        policy.WithOrigins(corsOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod();
});

app.MapControllers();
app.UseHttpsRedirection();
app.Run();