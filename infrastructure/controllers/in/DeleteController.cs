using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/controller/[in]")]
public class DeleteController : ControllerBase
{
    [HttpDelete]
    public IActionResult DeleteWallet()
    {
        return Ok("GET request received");
    }
    
    [HttpDelete("calendar/{id}")]
    public IActionResult DeleteCalendar(string id)
    {
        return Ok("GET request received");
    }
    
    [HttpDelete("event/{id}")]
    public IActionResult DeleteEvent(string id)
    {
        return Ok("GET request received");
    }
}