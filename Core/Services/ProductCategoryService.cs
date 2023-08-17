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

public sealed class ProductCategoryService : IProductCategoryService
{
    private readonly IRepository<ProductCategoryEntity> productCategoryRepository;
    private readonly IRepository<CategoryEntity> categoryRepository;
    private readonly IRepository<ProductEntity> productRepository;
    private readonly IProductCategoryMapper productCategoryMapper;
    private readonly IUnitOfWorkFactory unitOfWorkFactory;
    private readonly IResultFactory resultFactory;

    public ProductCategoryService(
        IRepository<ProductCategoryEntity> productCategoryRepository,
        IRepository<CategoryEntity> categoryRepository,
        IRepository<ProductEntity> productRepository,
        IProductCategoryMapper productCategoryMapper,
        IUnitOfWorkFactory unitOfWorkFactory,
        IResultFactory resultFactory
        )
    {
        this.productCategoryRepository = productCategoryRepository;
        this.productRepository = productRepository;
        this.categoryRepository = categoryRepository;
        this.productCategoryMapper = productCategoryMapper;
        this.unitOfWorkFactory = unitOfWorkFactory;
        this.resultFactory = resultFactory;
    }

    public async Task<Result<ProductCategoryResponse>> Create(int productId, int categoryId)
    {
        var product = await productRepository.GetOrDefault(productId) ?? throw new ResourceNotFoundException(nameof(productId));
        var category = await categoryRepository.GetOrDefault(categoryId) ?? throw new ResourceNotFoundException(nameof(categoryId));

        var entity = new ProductCategoryEntity
        {
            Category = category,
            CategoryId = categoryId,
            Product = product,
            ProductId = productId
        };

        using (var transaction = unitOfWorkFactory.BeginTransaction())
        {
            await productCategoryRepository.Add(entity);
            await transaction.Commit();
        }

        var result = productCategoryMapper.Map(entity);
        return result;
    }

    public async Task<Result> Delete(int productId, int categoryId)
    {
        var specification = new GetProductCategorySpecification(productId, categoryId);
        var entity = await productCategoryRepository.GetOrDefault(specification) ?? throw new ResourceNotFoundException($"Could not find with productId={productId}, categoryId={categoryId} any product category.");
        using (var transaction = unitOfWorkFactory.BeginTransaction())
        {
            await productCategoryRepository.Delete(entity);
            await transaction.Commit();
        }

        var result = resultFactory.Success();
        return result;
    }
}
