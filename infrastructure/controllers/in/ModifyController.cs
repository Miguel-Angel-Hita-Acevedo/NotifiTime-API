using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    
    [HttpPost("Event/{eventId}", Name = "UpdateEvent")]
    public IActionResult UpdateEvent()
    {
        return Ok(
        new{
            text = "UpdateEvent"
        });
    }
    
    
}
