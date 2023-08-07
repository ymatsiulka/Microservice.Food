using System.Reflection;
using ArchitectProg.Persistence.EfCore.PostgreSQL.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Microservice.Food.Infrastructure.Persistence;

public sealed class ApplicationDatabaseContext : DbContext
{
    private readonly DatabaseSettings databaseSettings;

    public ApplicationDatabaseContext(IOptions<DatabaseSettings> databaseSettings)
    {
        this.databaseSettings = databaseSettings.Value;

        ChangeTracker.LazyLoadingEnabled = false;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(databaseSettings.ConnectionString)
            .UseSnakeCaseNamingConvention();
    }
}
