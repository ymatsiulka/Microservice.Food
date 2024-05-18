using ArchitectProg.Persistence.EfCore.PostgreSQL;
using ArchitectProg.Persistence.EfCore.PostgreSQL.Settings;
using Microservice.Food.Infrastructure.Persistence;
using Microservice.Food.Modules.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Food.Modules;

public sealed class PersistenceModule : IModule
{
    public void RegisterDependencies(WebApplicationBuilder builder)
    {
        // need to add override in EF core for this interceptor
        //builder.Services.AddSingleton<UpdateAuditableEntitiesInterceptor>();
        var configuration = builder.Configuration;
        var databaseSettingsConfigurationSection = configuration.GetSection(nameof(DatabaseSettings));
        builder.Services.AddDatabase<ApplicationDatabaseContext>(databaseSettingsConfigurationSection);
        builder.Services.AddDbContext<DbContext, ApplicationDatabaseContext>();
    }
}
