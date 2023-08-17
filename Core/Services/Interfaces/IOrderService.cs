using Microservice.Food.Core.Contracts.Requests;

namespace Microservice.Food.Core.Services.Interfaces;

public interface IOrderService
{
    Task CreateOrder(CreateOrderRequest request);
}
