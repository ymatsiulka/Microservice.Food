using ArchitectProg.WebApi.Extensions.Attributes;
using Microservice.Food.Core.Contracts.Requests;
using Microservice.Food.Core.Contracts.Responses;
using Microservice.Food.Core.Services.Interfaces;
using Microservice.Food.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Food.Controllers;

[ApiController]
[Route("api/food/orders")]
[Tags("Orders")]
public sealed class OrderController : ControllerBase
{
    private readonly IOrderService orderService;

    public OrderController(IOrderService orderService)
    {
        this.orderService = orderService;
    }


    [ProducesNotFound]
    [ProducesBadRequest]
    [ProducesCreated(typeof(OrderResponse))]
    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderRequest request)
    {
        var result = await orderService.CreateOrder(request);
        var response = result.MatchActionResult(Ok);
        return response;
    }

    [ProducesNotFound]
    [ProducesBadRequest]
    [ProducesCreated(typeof(OrderResponse))]
    [HttpGet]
    public async Task<IActionResult> Get(int orderId)
    {
        var result = await orderService.GetOrder(orderId);
        var response = result.MatchActionResult(Ok);
        return response;
    }
}
