﻿using ArchitectProg.Kernel.Extensions.Exceptions;
using ArchitectProg.Kernel.Extensions.Interfaces;
using Microservice.Food.Core.Contracts.Requests;
using Microservice.Food.Core.Contracts.Responses;
using Microservice.Food.Core.Mappers.Interfaces;
using Microservice.Food.Core.Services.Interfaces;
using Microservice.Food.Domain.Entities;

namespace Microservice.Food.Core.Services;

public sealed class ProductService : IProductService
{
    private readonly IRepository<ProductEntity> productRepository;
    private readonly IUnitOfWorkFactory unitOfWorkFactory;
    private readonly IProductMapper productMapper;

    public ProductService(IUnitOfWorkFactory unitOfWorkFactory, 
        IRepository<ProductEntity> productRepository,
        IProductMapper productMapper)
    {
        this.productRepository = productRepository;
        this.unitOfWorkFactory = unitOfWorkFactory;
        this.productMapper = productMapper;
    }

    public async Task<ProductResponse> Create(CreateProductRequest request)
    {
        var entity = new ProductEntity
        {
            Description = request.Description,
            Discount = request.Discount,
            ImageUrl = request.ImageUrl,
            Name = request.Name,
            Price = request.Price,
            Categories = new List<CategoryEntity>()
        };

        using (var transaction = unitOfWorkFactory.BeginTransaction())
        {
            await productRepository.Add(entity);
            await transaction.Commit();
        }

        var response = productMapper.Map(entity);
        return response;
    }

    public async Task Update(int productId, UpdateProductRequest request)
    {
        if (productId != request.Id)
            throw new ValidationException("Ids are not equals");

        var entity = await productRepository.GetOrDefault(productId) ?? throw new ResourceNotFoundException(nameof(productId));

        entity.Description = request.Description;
        entity.Discount = request.Discount;
        entity.ImageUrl = request.ImageUrl;
        entity.Name = request.Name;
        entity.Price = request.Price;

        using (var transaction = unitOfWorkFactory.BeginTransaction())
        {
            await productRepository.Update(entity);
            await transaction.Commit();
        }
    }

    public async Task Delete(int productId)
    {
        var entity = await productRepository.GetOrDefault(productId) ?? throw new ResourceNotFoundException(nameof(productId));

        using (var transaction = unitOfWorkFactory.BeginTransaction())
        {
            await productRepository.Delete(entity);
            await transaction.Commit();
        }
    }

    public async Task<ProductResponse> Get(int productId)
    {
        var entity = await productRepository.GetOrDefault(productId) ?? throw new ResourceNotFoundException(nameof(productId));

        var response = productMapper.Map(entity);
        return response;
    }
}
