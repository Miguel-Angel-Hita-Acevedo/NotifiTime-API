using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/controller/in")]
public class ModifyController : ControllerBase
{
    [HttpPost]
    public IActionResult ModifyCalendarName()
    {
        return Ok("GET request received");
    }
    
    [HttpPost]
    public IActionResult ModifyEvent()
    {
        return Ok("GET request received");
    }
}
