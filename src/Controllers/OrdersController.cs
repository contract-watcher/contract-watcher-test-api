using System.Text.Json;
using ContractWatcher.SDK.AspNetCore.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace ContractWatcher.TestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    [HttpPost]
    [ContractWatcher("orders")]
    public IActionResult Create([FromBody] JsonElement request) =>
        Ok(new { Message = "Request accepted", Payload = request });
}