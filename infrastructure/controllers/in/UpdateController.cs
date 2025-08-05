using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotifiTime_API.application.DTOs;
using NotifiTime_API.infrastructure.adapters;

[ApiController]
[Route("Update")]
public class UpdateController : ControllerBase
{
    [HttpPost("Calendar/{calendarId}/{newName}", Name = "UpdateCalendarName")]
    public IActionResult UpdateCalendarName(Guid calendarId, string newName)
    {
        return Ok(new CalendarJsonAdapter().UpdateCalendarName(calendarId, newName));
    }
    
    [HttpPost("Event/{calendarId}", Name = "UpdateEvent")]
    public IActionResult UpdateEvent(Guid calendarId, [FromBody] EventCalendarDTO eventJson)
    {
        return Ok(new CalendarJsonAdapter().UpdateEvent(calendarId, eventJson));
    }
}
