using Microsoft.AspNetCore.Mvc;
using RetireBefore30.Contracts.Strategies;
using RetireBefore30.Models;
using RetireBefore30.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetireBefore30.Controllers
{
    [ApiController]
    [Route("api/")]
    public class PingController : Controller
    {
        private readonly IPingService _pingService;


        public PingController(IPingService pingService)
        {
            _pingService = pingService;
        }

        [HttpGet("v1/pings/{pingId}")]
        public async Task<IActionResult> getPingById([FromRoute]int pingId)
        {
            var ping = await _pingService.getPingById(pingId);

            if(ping == null)
            {
                return NotFound();
            }

            return Ok(ping);
        }

        [HttpGet("v1/pings")]
        public async Task<IActionResult> getPings()
        {
            return Ok(await _pingService.getPings());
        }

        [HttpDelete("v1/pings/{pingId}")]
        public async Task<IActionResult> deletePing([FromRoute] int pingId)
        {
            var wasDeleted = await _pingService.deletePing(pingId);

            if (!wasDeleted)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost("v1/pings")]
        public async Task<IActionResult> createPing([FromBody] PingRequest request)
        {
            var ping = new Ping
            { 
                Timestamp = DateTime.Now,
                State = request.State,
                StrategyInstanceId = request.StrategyInstanceId
            };

           await _pingService.createPing(ping);
          
            return Ok(ping);
        }

        [HttpPut("v1/pings")]
        public async Task<IActionResult> updatePing(PingRequest request)
        {
            var ping = new Ping
            {
                Timestamp = DateTime.Now,
                State = request.State,
                StrategyInstanceId = request.StrategyInstanceId
            };

            var wasUpdated = await _pingService.updatePing(ping);

            if (!wasUpdated)
            {
                return NotFound();
            }

            return Ok(ping);
        }


    }
}
