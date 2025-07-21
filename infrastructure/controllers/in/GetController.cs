using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/controller/getCalendar")]
public class GetController : ControllerBase
{
    [HttpGet]
    public IActionResult GetCalendars()
    {
        return Ok(
        new{
            text = "FUNCIONAA"
        });
    }
    /*
    [HttpGet]
    public IActionResult GetEventsOfCalendar()
    {
        return Ok("GET request received");
    }*/
}