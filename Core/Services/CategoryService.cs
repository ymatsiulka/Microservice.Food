using ArchitectProg.Kernel.Extensions.Exceptions;
using ArchitectProg.Kernel.Extensions.Factories.Interfaces;
using ArchitectProg.Kernel.Extensions.Interfaces;
using ArchitectProg.Kernel.Extensions.Utils;
using Microservice.Food.Core.Contracts.Requests;
using Microservice.Food.Core.Contracts.Responses;
using Microservice.Food.Core.Mappers.Interfaces;
using Microservice.Food.Core.Services.Interfaces;
using Microservice.Food.Domain.Entities;

namespace Microservice.Food.Core.Services;

public sealed class CategoryService : ICategoryService
{
    private readonly IRepository<CategoryEntity> categoryRepository;
    private readonly IUnitOfWorkFactory unitOfWorkFactory;
    private readonly IResultFactory resultFactory;
    private readonly ICategoryMapper categoryMapper;

    public CategoryService(IRepository<CategoryEntity> categoryRepository,
        IUnitOfWorkFactory unitOfWorkFactory,
        ICategoryMapper categoryMapper,
        IResultFactory resultFactory)
    {
        this.categoryRepository = categoryRepository;
        this.unitOfWorkFactory = unitOfWorkFactory;
        this.categoryMapper = categoryMapper;
        this.resultFactory = resultFactory;
    }

    public async Task<Result<CategoryResponse>> Create(CreateCategoryRequest request)
    {
        var entity = new CategoryEntity
        {
            Name = request.Name,
            Products = new List<ProductEntity>()
        };

        using (var transaction = unitOfWorkFactory.BeginTransaction())
        {
            await categoryRepository.Add(entity);
            await transaction.Commit();
        }

        var response = categoryMapper.Map(entity);
        return response;
    }

    public async Task<Result> Delete(int categoryId)
    {
        var entity = await categoryRepository.GetOrDefault(categoryId) ?? throw new ResourceNotFoundException(nameof(categoryId));

        using (var transaction = unitOfWorkFactory.BeginTransaction())
        {
            await categoryRepository.Delete(entity);
            await transaction.Commit();
        }

        var response = resultFactory.Success();
        return response;
    }

    public async Task<Result<CategoryResponse>> Get(int categoryId)
    {
        var entity = await categoryRepository.GetOrDefault(categoryId) ?? throw new ResourceNotFoundException(nameof(categoryId));

        var response = categoryMapper.Map(entity);
        return response;
    }

    public async Task<Result> Update(int categoryId, UpdateCategoryRequest request)
    {
        if (categoryId != request.Id)
            throw new ValidationException("Ids are not equals");

        var entity = await categoryRepository.GetOrDefault(categoryId) ?? throw new ResourceNotFoundException(nameof(categoryId));

        entity.Name = request.Name;

        using (var transaction = unitOfWorkFactory.BeginTransaction())
        {
            await categoryRepository.Update(entity);
            await transaction.Commit();
        }

        var response = resultFactory.Success();
        return response;
    }
}
