using ArchitectProg.WebApi.Extensions.Attributes;
using Microservice.Food.Core.Contracts.Requests;
using Microservice.Food.Core.Contracts.Responses;
using Microservice.Food.Core.Services.Interfaces;
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

        return CreatedAtAction(nameof(Get), new { productId = result.Id }, result);
    }

    [ProducesBadRequest]
    [ProducesNoContent]
    [HttpPut("{productId}")]
    public async Task<IActionResult> Update(int productId, UpdateProductRequest request)
    {
        await productService.Update(productId, request);
        return NoContent();
    }

    [ProducesBadRequest]
    [ProducesNotFound]
    [ProducesNoContent]
    [HttpDelete("{productId}")]
    public async Task<IActionResult> Delete(int productId)
    {
        await productService.Delete(productId);
        return NoContent();
    }

    [ProducesNotFound]
    [ProducesOk(typeof(ProductResponse))]
    [HttpGet("{productId}")]
    public async Task<IActionResult> Get(int productId)
    {
        var result = await productService.Get(productId);
        return Ok(result);
    }
}
