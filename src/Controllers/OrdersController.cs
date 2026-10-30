using ContractWatcher.SDK.AspNetCore.Attributes;
using ContractWatcher.TestApi.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ContractWatcher.TestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class OrdersController : ControllerBase
{
    [HttpPost]
    [ContractWatcher("orders")]
    public IActionResult Create([FromBody] CreateOrderRequest request) =>
        Ok(new
        {
            Message = "Request accepted",
            Payload = request
        });
}