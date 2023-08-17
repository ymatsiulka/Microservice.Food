using ArchitectProg.WebApi.Extensions.Attributes;
using Microservice.Food.Core.Contracts.Requests;
using Microservice.Food.Core.Contracts.Responses;
using Microservice.Food.Core.Services.Interfaces;
using Microservice.Food.Extensions;
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

        var response = result.MatchActionResult(x => CreatedAtAction(nameof(Get), new { categoryId = x.Id }, x));
        return response;
    }

    [ProducesBadRequest]
    [ProducesNoContent]
    [HttpPut("{categoryId}")]
    public async Task<IActionResult> Update(int categoryId, UpdateCategoryRequest request)
    {
        var result = await categoryService.Update(categoryId, request);

        var response = result.MatchActionResult(NoContent);
        return response;
    }

    [ProducesBadRequest]
    [ProducesNotFound]
    [ProducesNoContent]
    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> Delete(int categoryId)
    {
        var result = await categoryService.Delete(categoryId);

        var response = result.MatchActionResult(NoContent);
        return response;
    }

    [ProducesNotFound]
    [ProducesOk(typeof(CategoryResponse))]
    [HttpGet("{categoryId}")]
    public async Task<IActionResult> Get(int categoryId)
    {
        var result = await categoryService.Get(categoryId);

        var response = result.MatchActionResult(Ok);
        return response;
    }
}
