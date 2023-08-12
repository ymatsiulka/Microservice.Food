using ArchitectProg.FunctionalExtensions;
using ArchitectProg.Kernel.Extensions;
using Microservice.Food.Core.Mappers;
using Microservice.Food.Core.Mappers.Interfaces;
using Microservice.Food.Core.Services;
using Microservice.Food.Core.Services.Interfaces;
using Microservice.Food.Core.Settings;
using Microservice.Food.Modules.Interfaces;

namespace Microservice.Food.Modules;

public sealed class CoreModule : IModule
{
    public void RegisterDependencies(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IProductMapper, ProductMapper>();

        builder.Services.AddKernelExtensions();
        builder.Services.AddFunctionalExtensions();
        
        var configuration = builder.Configuration;
        builder.Services.Configure<RetryPolicySettings>(configuration.GetSection(nameof(RetryPolicySettings)));
    }
}
