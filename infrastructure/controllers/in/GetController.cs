using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/controller/[in]")]
public class GetController : ControllerBase
{
    [HttpGet]
    public IActionResult GetCalendars()
    {
        return Ok("GET request received");
    }
    
    [HttpGet]
    public IActionResult GetEventsOfCalendar()
    {
        return Ok("GET request received");
    }
}