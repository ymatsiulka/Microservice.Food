using ArchitectProg.WebApi.Extensions.Attributes;
using Microservice.Food.Core.Contracts.Requests;
using Microservice.Food.Core.Contracts.Responses;
using Microservice.Food.Core.Services.Interfaces;
using Microservice.Food.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Food.Controllers;

[ApiController]
[Route("api/food/products")]
[Tags("Products")]
public sealed class ProductController : ControllerBase
{
    private readonly IProductService productService;

    public ProductController(IProductService productService)
    {
        this.productService = productService;
    }

    [ProducesBadRequest]
    [ProducesCreated(typeof(ProductResponse))]
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest request)
    {
        var result = await productService.Create(request);

        var response = result.MatchActionResult(x => CreatedAtAction(nameof(Get), new { productId = x.Id }, x));
        return response;
    }

    [ProducesBadRequest]
    [ProducesNoContent]
    [HttpPut("{productId}")]
    public async Task<IActionResult> Update(int productId, UpdateProductRequest request)
    {
        var result = await productService.Update(productId, request);

        var response = result.MatchActionResult(NoContent);
        return response;
    }

    [ProducesBadRequest]
    [ProducesNotFound]
    [ProducesNoContent]
    [HttpDelete("{productId}")]
    public async Task<IActionResult> Delete(int productId)
    {
        var result = await productService.Delete(productId);

        var response = result.MatchActionResult(NoContent);
        return response;
    }

    [ProducesNotFound]
    [ProducesOk(typeof(ProductResponse))]
    [HttpGet("{productId}")]
    public async Task<IActionResult> Get(int productId)
    {
        var result = await productService.Get(productId);

        var response = result.MatchActionResult(Ok);
        return response;
    }
}
