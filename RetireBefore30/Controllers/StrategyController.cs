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
    public class StrategyController : Controller
    {
        private readonly IStrategyService _strategyService;


        public StrategyController(IStrategyService strategyService)
        {
            _strategyService = strategyService;
        }

        [HttpGet("v1/strategies/{strategyId}")]
        public async Task<IActionResult> getStrategyById([FromRoute]int strategyId)
        {
            var strategy = await _strategyService.getStrategyById(strategyId);

            if(strategy == null)
            {
                return NotFound();
            }

            return Ok(strategy);
        }

        [HttpGet("v1/strategies")]
        public async Task<IActionResult> getStrategies()
        {
            return Ok(await _strategyService.getStrategies());
        }

        [HttpDelete("v1/strategies/{strategyId}")]
        public async Task<IActionResult> deleteStrategy([FromRoute] int strategyId)
        {
            var wasDeleted = await _strategyService.deleteStrategy(strategyId);

            if (!wasDeleted)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost("v1/strategies")]
        public async Task<IActionResult> createStrategy([FromBody] StrategyRequest request)
        {
            var strategy = new Strategy { 
                Name = request.Name,
                CreateDate = DateTime.Now
            };

           await _strategyService.createStrategy(strategy);
          
            return Ok(strategy);
        }

        [HttpPut("v1/strategies")]
        public async Task<IActionResult> updateStrategy(StrategyRequest request)
        {
            var strategy = new Strategy
            {
                Name = request.Name,
                CreateDate = DateTime.Now
            };

            var wasUpdated = await _strategyService.updateStrategy(strategy);

            if (!wasUpdated)
            {
                return NotFound();
            }

            return Ok(strategy);
        }


    }
}
