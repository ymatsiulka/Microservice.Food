using ArchitectProg.Kernel.Extensions.Utils;
using Microservice.Food.Core.Contracts.Responses;

namespace Microservice.Food.Core.Services.Interfaces;

public interface IOrderProductService
{
    Task<Result<OrderProductResponse>> Create(int orderId, int productId);
    Task<Result> Delete(int orderId, int productId);
}
