using ArchitectProg.Kernel.Extensions.Utils;
using Microservice.Food.Core.Contracts.Requests;
using Microservice.Food.Core.Contracts.Responses;

namespace Microservice.Food.Core.Services.Interfaces;

public interface IOrderService
{
    Task<Result<OrderResponse>> CreateOrder(CreateOrderRequest request);
    Task<Result<OrderResponse>> GetOrder(int orderId);
}
