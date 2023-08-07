using ArchitectProg.FunctionalExtensions;
using ArchitectProg.Kernel.Extensions;
using Microservice.Food.Core.Settings;
using Microservice.Food.Modules.Interfaces;

namespace Microservice.Food.Modules;

public sealed class CoreModule : IModule
{
    public void RegisterDependencies(WebApplicationBuilder builder)
    {
        builder.Services.AddKernelExtensions();
        builder.Services.AddFunctionalExtensions();
        var configuration = builder.Configuration;
        builder.Services.Configure<RetryPolicySettings>(configuration.GetSection(nameof(RetryPolicySettings)));
    }
}
