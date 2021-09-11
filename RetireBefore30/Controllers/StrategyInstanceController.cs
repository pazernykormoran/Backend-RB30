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
        public async Task<IActionResult> getStrategyInstances()
        {
            return Ok(await _strategyInstanceService.getStrategyInstances());
        }

        [HttpDelete("v1/instances/{instanceId}")]
        public async Task<IActionResult> deleteStrategyInstance([FromRoute] int instanceId)
        {
            var wasDeleted = await _strategyInstanceService.deleteStrategyInstance(instanceId);

            if (!wasDeleted)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost("v1/instances")]
        public async Task<IActionResult> createStrategyInstance([FromBody] StrategyInstanceRequest request)
        {
            var strategyInstance = new StrategyInstance
            { 
                Name = request.Name,
                CreateDate = DateTime.Now,
                Type = request.Type,
                Instrument = request.Instrument,
                StrategyId = request.StrategyId
            };

           await _strategyInstanceService.createStrategyInstance(strategyInstance);
          
            return Ok(strategyInstance);
        }

        [HttpPut("v1/instances")]
        public async Task<IActionResult> updateStrategyInstance(StrategyInstanceRequest request)
        {
            var strategyInstance = new StrategyInstance
            {
                Name = request.Name,
                CreateDate = DateTime.Now,
                Type = request.Type,
                Instrument = request.Instrument,
                StrategyId = request.StrategyId
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
