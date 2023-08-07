namespace Microservice.Food.Modules.Interfaces;

public interface IModule
{
    void RegisterDependencies(WebApplicationBuilder builder);
}
