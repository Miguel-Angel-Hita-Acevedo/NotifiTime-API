using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotifiTime_API.infrastructure.adapters;
using NotifiTime_API.infrastructure.configuration;

[ApiController]
[Route("Main")]
public class OpenCloseController : ControllerBase
{
    [HttpGet("Start")]
    public IActionResult Start()
    {
        return Ok(WalletConfiguration.GetWalletConfiguration().Start());
    }
    
    [HttpGet("Close")]
    public IActionResult Close()
    {
        return Ok(WalletConfiguration.GetWalletConfiguration().Close());
    }
}