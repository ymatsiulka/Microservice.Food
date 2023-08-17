using ArchitectProg.FunctionalExtensions.Extensions;
using ArchitectProg.Kernel.Extensions.Exceptions;
using ArchitectProg.Kernel.Extensions.Interfaces;
using Microservice.Food.Core.Contracts.Requests;
using Microservice.Food.Core.Services.Interfaces;
using Microservice.Food.Domain.Entities;
using Microservice.Food.Infrastructure.Persistence.Specifications;

namespace Microservice.Food.Core.Services;

public sealed class OrderService : IOrderService
{
    private readonly IRepository<ProductEntity> productRepository;
    private readonly IRepository<OrderEntity> orderRepository;
    public OrderService(IRepository<ProductEntity> productRepository,
        IRepository<OrderEntity> orderRepository)
    {
        this.productRepository = productRepository;
        this.orderRepository = orderRepository;
    }

    public async Task CreateOrder(CreateOrderRequest request)
    {
        var productsSpecification = new ListProductsSpecification(request.ProductIds);
        var products = await productRepository.List(productsSpecification);

        if (products.Length != request.ProductIds.Length)
        {
            var findedProductsIds = products.Select(t => t.Id).ToArray();
            var notFoundedProductsIds = string.Join(", ", request.ProductIds.Where(t => !findedProductsIds.Contains(t)).ToArray());
            throw new ValidationException($"Could not find all selected products : {notFoundedProductsIds}");
        }

        var order = new OrderEntity
        {
            Description = request.Description,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Status = Domain.Enums.OrderStatus.Draft,
            Total = products.Sum(t => t.Price),
        };



    }
}
