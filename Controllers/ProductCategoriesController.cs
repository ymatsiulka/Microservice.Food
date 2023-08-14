using ArchitectProg.WebApi.Extensions.Attributes;
using Microservice.Food.Core.Contracts.Responses;
using Microservice.Food.Core.Services.Interfaces;
using Microservice.Food.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Food.Controllers;


[ApiController]
[Route("api/food/products")]
public sealed class ProductCategoriesController : ControllerBase
{
    private readonly IProductCategoryService productCategoryService;

    public ProductCategoriesController(IProductCategoryService productCategoryService)
    {
        this.productCategoryService = productCategoryService;
    }

    [ProducesNotFound]
    [ProducesBadRequest]
    [ProducesCreated(typeof(ProductCategoryResponse))]
    [HttpPost("{productId}/categories/{categoryId}")]
    public async Task<IActionResult> Create(int productId, int categoryId)
    {
        var result = await productCategoryService.Create(productId, categoryId);

        var response = result.MatchActionResult(Ok);
        return response;
    }

    [ProducesBadRequest]
    [ProducesNotFound]
    [ProducesNoContent]
    [HttpDelete("{productId}/categories/{categoryId}")]
    public async Task<IActionResult> Delete(int productId, int categoryId)
    {
        var result = await productCategoryService.Delete(productId, categoryId);

        var response = result.MatchActionResult(NoContent);
        return response;
    }
}
