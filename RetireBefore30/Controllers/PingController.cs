using Microsoft.AspNetCore.Mvc;
using RetireBefore30.Contracts.Pings;
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
        public async Task<IActionResult> getPings([FromQuery] PingsGetRequest request)
        {
            DateTime fromDate;
            DateTime toDate;
            if (request.from == -1) fromDate = DateTimeOffset.FromUnixTimeMilliseconds(0).UtcDateTime;
            else fromDate = DateTimeOffset.FromUnixTimeMilliseconds(request.from).UtcDateTime;
            if (request.to == -1) toDate = DateTime.Now;
            else toDate = DateTimeOffset.FromUnixTimeMilliseconds(request.to).UtcDateTime;
            return Ok(await _pingService.getPings(request.instanceId ?? 0, fromDate, toDate));

        }

        [HttpDelete("v1/pings/{pingId}")]
        public async Task<IActionResult> deletePing([FromRoute] int pingId)
        {
            var wasDeleted = await _pingService.deletePing(pingId);

            if (!wasDeleted)
            {
                return NotFound();
            }

            return Ok("Ping deleted");
        }

        [HttpPost("v1/pings")]
        public async Task<IActionResult> createPing([FromBody] PingsPostRequest request)
        {
            var ping = new Ping
            { 
                Timestamp = DateTimeOffset.FromUnixTimeMilliseconds(request.timestamp ?? new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds()).UtcDateTime,
                State = request.state?? -1,
                StrategyInstanceId = request.instanceId??-1
            };

           await _pingService.createPing(ping);
          
            return Ok(ping);
        }

        [HttpPut("v1/pings")]
        public async Task<IActionResult> updatePing(PingsPutRequest request)
        {
            var ping = new Ping
            {
                Id = request.id?? -1,
                Timestamp = DateTimeOffset.FromUnixTimeMilliseconds(request.timestamp ?? 0).UtcDateTime,
                State = request.state ?? -1,
                StrategyInstanceId = request.instanceId ?? -1
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
