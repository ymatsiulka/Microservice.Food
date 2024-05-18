using Microservice.Food.Core.Contracts.Responses;

namespace Microservice.Food.Core.Services.Interfaces;

public interface IOrderProductService
{
    Task<OrderProductResponse> Create(int orderId, int productId);
    Task Delete(int orderId, int productId);
}
