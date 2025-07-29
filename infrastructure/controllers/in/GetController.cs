using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotifiTime_API.infrastructure.adapters;

[ApiController]
[Route("Get/Calendar")]
public class GetController : ControllerBase
{
    [HttpGet("All")]
    public IActionResult GetCalendars()
    {
        return Ok(new CalendarJsonAdapter().GetAllCalendars());
    }
    
    [HttpGet("Events/{calendarId}", Name = "EventsOfCalendar")]
    public IActionResult GetEventsOfCalendar(Guid calendarId)
    {
        return Ok(new CalendarJsonAdapter().GetEventsInCalendar(calendarId));
    }
}