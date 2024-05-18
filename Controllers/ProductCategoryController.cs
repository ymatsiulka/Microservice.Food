using ArchitectProg.WebApi.Extensions.Attributes;
using Microservice.Food.Core.Contracts.Responses;
using Microservice.Food.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Food.Controllers;

[ApiController]
[Route("api/food/products")]
public sealed class ProductCategoryController : ControllerBase
{
    private readonly IProductCategoryService productCategoryService;

    public ProductCategoryController(IProductCategoryService productCategoryService)
    {
        this.productCategoryService = productCategoryService;
    }

    [ProducesNotFound]
    [ProducesBadRequest]
    [ProducesOk(typeof(ProductCategoryResponse))]
    [HttpPost("{productId}/categories/{categoryId}")]
    public async Task<IActionResult> Create(int productId, int categoryId)
    {
        var result = await productCategoryService.Create(productId, categoryId);
        return Ok(result);
    }

    [ProducesBadRequest]
    [ProducesNotFound]
    [ProducesNoContent]
    [HttpDelete("{productId}/categories/{categoryId}")]
    public async Task<IActionResult> Delete(int productId, int categoryId)
    {
        await productCategoryService.Delete(productId, categoryId);
        return NoContent();
    }
}
