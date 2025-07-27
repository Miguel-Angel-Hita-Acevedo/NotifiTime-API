using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Get/Calendar")]
public class GetController : ControllerBase
{
    [HttpGet("All")]
    public IActionResult GetCalendars()
    {
        return Ok(
        new{
            text = "GetCalendars"
        });
    }
    
    [HttpGet("Events/{calendarId}", Name = "EventsOfCalendar")]
    public IActionResult GetEventsOfCalendar(string calendarId)
    {
        return Ok(
        new{
            text = "GetEventsOfCalendar"
        });
    }
}