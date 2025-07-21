using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/controller/out")]
public class EventHandler : ControllerBase
{
    [HttpGet]
    public IActionResult CheckPendingEvent()
    {
        return Ok("GET request received");
    }
}