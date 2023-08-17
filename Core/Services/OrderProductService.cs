using ArchitectProg.Kernel.Extensions.Exceptions;
using ArchitectProg.Kernel.Extensions.Factories.Interfaces;
using ArchitectProg.Kernel.Extensions.Interfaces;
using ArchitectProg.Kernel.Extensions.Utils;
using Microservice.Food.Core.Contracts.Responses;
using Microservice.Food.Core.Mappers.Interfaces;
using Microservice.Food.Core.Services.Interfaces;
using Microservice.Food.Domain.Entities;
using Microservice.Food.Infrastructure.Persistence.Specifications;

namespace Microservice.Food.Core.Services;

public sealed class OrderProductService : IOrderProductService
{
    private readonly IRepository<OrderProductEntity> orderProductRepository;
    private readonly IRepository<ProductEntity> productRepository;
    private readonly IRepository<OrderEntity> orderRepository;
    private readonly IOrderProductMapper orderProductMapper;
    private readonly IUnitOfWorkFactory unitOfWorkFactory;
    private readonly IResultFactory resultFactory;

    public OrderProductService(IRepository<OrderProductEntity> orderProductRepository,
        IRepository<ProductEntity> productRepository,
        IRepository<OrderEntity> orderRepository,
        IOrderProductMapper orderProductMapper,
        IUnitOfWorkFactory unitOfWorkFactory,
        IResultFactory resultFactory)
    {
        this.orderProductRepository = orderProductRepository;
        this.productRepository = productRepository;
        this.orderRepository = orderRepository;
        this.orderProductMapper = orderProductMapper;
        this.unitOfWorkFactory = unitOfWorkFactory;
        this.resultFactory = resultFactory;
    }

    public async Task<Result<OrderProductResponse>> Create(int orderId, int productId)
    {
        var order = await orderRepository.GetOrDefault(orderId) ?? throw new ResourceNotFoundException(nameof(orderId));
        var product = await productRepository.GetOrDefault(productId) ?? throw new ResourceNotFoundException(nameof(productId));

        var entity = new OrderProductEntity
        {
            Order = order,
            OrderId = orderId,
            Product = product,
            ProductId = productId
        };

        using (var transaction = unitOfWorkFactory.BeginTransaction())
        {
            await orderProductRepository.Add(entity);
            await transaction.Commit();
        }

        var result = orderProductMapper.Map(entity);
        return result;
    }

    public async Task<Result> Delete(int orderId, int productId)
    {
        var specification = new GetOrderProductSpecification(orderId, productId);
        var entity = await orderProductRepository.GetOrDefault(specification) ?? throw new ResourceNotFoundException($"Could not find with productId={productId}, orderId={orderId} any order product.");

        using (var transaction = unitOfWorkFactory.BeginTransaction())
        {
            await orderProductRepository.Delete(entity);
            await transaction.Commit();
        }

        var result = resultFactory.Success();
        return result;
    }
}
