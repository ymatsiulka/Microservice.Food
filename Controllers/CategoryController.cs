using ArchitectProg.WebApi.Extensions.Attributes;
using Microservice.Food.Core.Contracts.Requests;
using Microservice.Food.Core.Contracts.Responses;
using Microservice.Food.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Food.Controllers;

[ApiController]
[Route("api/food/categories")]
[Tags("Categories")]
public sealed class CategoryController : ControllerBase
{
    private readonly ICategoryService categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        this.categoryService = categoryService;
    }

    [ProducesBadRequest]
    [ProducesCreated(typeof(CategoryResponse))]
    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryRequest request)
    {
        var result = await categoryService.Create(request);
        return CreatedAtAction(nameof(Get), new { categoryId = result.Id }, result);
    }

    [ProducesBadRequest]
    [ProducesNoContent]
    [HttpPut("{categoryId}")]
    public async Task<IActionResult> Update(int categoryId, UpdateCategoryRequest request)
    {
        await categoryService.Update(categoryId, request);
        return NoContent();
    }

    [ProducesBadRequest]
    [ProducesNotFound]
    [ProducesNoContent]
    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> Delete(int categoryId)
    {
        await categoryService.Delete(categoryId);
        return NoContent();
    }

    [ProducesNotFound]
    [ProducesOk(typeof(CategoryResponse))]
    [HttpGet("{categoryId}")]
    public async Task<IActionResult> Get(int categoryId)
    {
        var result = await categoryService.Get(categoryId);
        return Ok(result);
    }
}
