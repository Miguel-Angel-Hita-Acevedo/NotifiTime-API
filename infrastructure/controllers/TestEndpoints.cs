using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NotifiTime_API.infrastructure.controllers
{
    // Esta clase está solo para probar que me estoy conectando correctamente
    [ApiController]
    [Route("api/[controller]")]
    public class TestEndpoints : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("GET request received");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"GET request with ID = {id}");
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok($"POST request with value = \"{value}\" received!");
        }
    }
}