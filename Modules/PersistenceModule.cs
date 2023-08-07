﻿using ArchitectProg.Persistence.EfCore.PostgreSQL;
using ArchitectProg.Persistence.EfCore.PostgreSQL.Settings;
using Microservice.Food.Infrastructure.Persistence;
using Microservice.Food.Modules.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Food.Modules;

public sealed class PersistenceModule : IModule
{
    public void RegisterDependencies(WebApplicationBuilder builder)
    {
        builder.Services.AddEfCoreRepository();
        builder.Services.AddDbContext<DbContext, ApplicationDatabaseContext>();

        var configuration = builder.Configuration;
        builder.Services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));
    }
}
