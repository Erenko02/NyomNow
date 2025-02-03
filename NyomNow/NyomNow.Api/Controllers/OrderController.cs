using Microsoft.AspNetCore.Mvc;
 using NyomNow.NyomNow.Api.Business;
using NyomNow.NyomNow.Api.Services;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
   

    private readonly IOrderService _orderBusinessService;

    public OrderController(IOrderService orderBusinessService)
    {
        _orderBusinessService = orderBusinessService;
    }

    [HttpGet("total-orders")]
    public async Task<IActionResult> GetTotalOrders()
    {
        var totalOrders = await _orderBusinessService.GetAllOrdersAsync();
        return Ok(totalOrders);
    }
}
