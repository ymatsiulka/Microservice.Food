using Microservice.Food.Core.Contracts.Requests;
using Microservice.Food.Core.Contracts.Responses;

namespace Microservice.Food.Core.Services.Interfaces;

public interface IOrderService
{
    Task<OrderResponse> CreateOrder(CreateOrderRequest request);
    Task<OrderResponse> GetOrder(int orderId);
}
