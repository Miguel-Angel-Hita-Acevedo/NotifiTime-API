using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("CheckEvents")]
public class EventStatus : ControllerBase
{
    [HttpGet]
    public IActionResult CheckPendingEvent()
    {
        return Ok(
        new{
            text = "CheckPendingEvent"
        });
    }
}