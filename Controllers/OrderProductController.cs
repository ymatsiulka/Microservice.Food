using ArchitectProg.WebApi.Extensions.Attributes;
using Microservice.Food.Core.Contracts.Responses;
using Microservice.Food.Core.Services.Interfaces;
using Microservice.Food.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Food.Controllers;

[ApiController]
[Route("api/food/orders")]
public sealed class OrderProductController : ControllerBase
{
    private readonly IOrderProductService orderProductService;

    public OrderProductController(IOrderProductService orderProductService)
    {
        this.orderProductService = orderProductService;
    }

    [ProducesNotFound]
    [ProducesBadRequest]
    [ProducesCreated(typeof(OrderProductResponse))]
    [HttpPost("{orderId}/products/{productId}")]
    public async Task<IActionResult> Create(int orderId, int productId)
    {
        var result = await orderProductService.Create(orderId, productId);

        var response = result.MatchActionResult(Ok);
        return response;
    }

    [ProducesBadRequest]
    [ProducesNotFound]
    [ProducesNoContent]
    [HttpDelete("{orderId}/products/{productId}")]
    public async Task<IActionResult> Delete(int orderId, int productId)
    {
        var result = await orderProductService.Delete(orderId, productId);

        var response = result.MatchActionResult(NoContent);
        return response;
    }
}
