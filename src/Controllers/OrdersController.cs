using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Schema;
using System.Text.Json.Serialization;
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
    
    [HttpPost]
    [ContractWatcher("orders")]
    public IActionResult Delete([FromBody] JsonElement request) =>
        Ok(new { Message = "Request accepted", Payload = request });
    
    [HttpPost]
    [ContractWatcher("orders")]
    public IActionResult Update([FromBody] JsonElement request) =>
        Ok(new { Message = "Request accepted", Payload = request });
}