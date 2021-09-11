using Microsoft.AspNetCore.Mvc;
using RetireBefore30.Contracts.StrategyInstances;
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
    public class StrategyInstanceController : Controller
    {
        private readonly IStrategyInstanceService _strategyInstanceService;


        public StrategyInstanceController(IStrategyInstanceService strategyInstanceService)
        {
            _strategyInstanceService = strategyInstanceService;
        }

        [HttpGet("v1/instances/{instanceId}")]
        public async Task<IActionResult> getStrategyInstanceById([FromRoute]int instanceId)
        {
            var strategyInstance = await _strategyInstanceService.getStrategyInstanceById(instanceId);

            if(strategyInstance == null)
            {
                return NotFound();
            }

            return Ok(strategyInstance);
        }

        [HttpGet("v1/instances")]
        public async Task<IActionResult> getStrategyInstances([FromQuery] int strategyId = -1)
        {
            if (strategyId == -1) return BadRequest("No strategyId in request");
            return Ok(await _strategyInstanceService.getStrategyInstances(strategyId));
        }

        [HttpDelete("v1/instances/{instanceId}")]
        public async Task<IActionResult> deleteStrategyInstance([FromRoute] int instanceId)
        {
            var wasDeleted = await _strategyInstanceService.deleteStrategyInstance(instanceId);

            if (!wasDeleted)
            {
                return NotFound();
            }

            return Ok("Strategy instance deleted");
        }

        [HttpPost("v1/instances")]
        public async Task<IActionResult> createStrategyInstance([FromBody] StrategyInstancesPostRequest request)
        {
            var strategyInstance = new StrategyInstance
            { 
                Name = request.name,
                CreateDate = DateTimeOffset.FromUnixTimeMilliseconds(request.createTimestamp ?? new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds()).UtcDateTime,
                Type = request.type??-1,
                Instrument = request.instrument,
                StrategyId = request.strategyId??-1
            };

           await _strategyInstanceService.createStrategyInstance(strategyInstance);
          
            return Ok(strategyInstance);
        }

        [HttpPut("v1/instances")]
        public async Task<IActionResult> updateStrategyInstance(StrategyInstancesPutRequest request)
        {
            var strategyInstance = new StrategyInstance
            {
                Id = request.id ?? -1,
                Name = request.name,
                CreateDate = DateTimeOffset.FromUnixTimeMilliseconds(request.createTimestamp ?? new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds()).UtcDateTime,
                Type = request.type ?? -1,
                Instrument = request.instrument,
                StrategyId = request.strategyId ?? -1
            };

            var wasUpdated = await _strategyInstanceService.updateStrategyInstance(strategyInstance);

            if (!wasUpdated)
            {
                return NotFound();
            }

            return Ok(strategyInstance);
        }


    }
}
