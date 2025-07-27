using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Modify")]
public class ModifyController : ControllerBase
{
    [HttpPost("Calendar/{calendarId}", Name = "ModifyCalendarName")]
    public IActionResult ModifyCalendarName(string  calendarId)
    {
        return Ok(
        new{
            text = "ModifyCalendarName"
        });
    }
    
    [HttpPost("Event/{eventId}", Name = "ModifyEvent")]
    public IActionResult ModifyEvent()
    {
        return Ok(
        new{
            text = "ModifyEvent"
        });
    }
}
