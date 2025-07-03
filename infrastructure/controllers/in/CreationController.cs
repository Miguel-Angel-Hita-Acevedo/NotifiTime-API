using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/controller/[in]")]
public class CreationController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateCalendar([FromBody] string name)
    {
        return Ok($"POST request with value = \"{name}\" received!");
    }
    
    [HttpPost]
    public IActionResult CreateEventInCalendar([FromBody] string value)
    {
        return Ok($"POST request with value = \"{value}\" received!");
    }
}