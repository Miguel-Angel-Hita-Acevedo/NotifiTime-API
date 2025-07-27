using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Delete")]
public class DeleteController : ControllerBase
{
    [HttpDelete("Wallet")]
    public IActionResult DeleteWallet()
    {
        return Ok(
        new{
            text = "DeleteWallet"
        });
    }
    
    [HttpDelete("Calendar/{calendarId}", Name = "DeleteCalendar")]
    public IActionResult DeleteCalendar(string calendarId)
    {
        return Ok(
        new{
            text = "DeleteCalendar"
        });
    }
    
    [HttpDelete("Event/{eventId}", Name = "DeleteEvent")]
    public IActionResult DeleteEvent(string eventId)
    {
        return Ok(
        new{
            text = "DeleteEvent"
        });
    }
}