using Microsoft.AspNetCore.Mvc;
using RetireBefore30.Contracts.Configs;
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
    public class ConfigController : Controller
    {
        private readonly IConfigService _configService;


        public ConfigController(IConfigService configService)
        {
            _configService = configService;
        }

        [HttpGet("v1/configs/{configId}")]
        public async Task<IActionResult> getConfigById([FromRoute]int configId)
        {
            var config = await _configService.getConfigById(configId);

            if(config == null)
            {
                return NotFound();
            }

            return Ok(config);
        }

        [HttpGet("v1/configs")]
        public async Task<IActionResult> getConfigs([FromQuery] int instanceId = -1)
        {
            if (instanceId == -1) return BadRequest("No instanceId in request");
            return Ok(await _configService.getConfigs(instanceId));
        }

        [HttpDelete("v1/configs/{configId}")]
        public async Task<IActionResult> deleteConfig([FromRoute] int configId)
        {
            var wasDeleted = await _configService.deleteConfig(configId);

            if (!wasDeleted)
            {
                return NotFound();
            }

            return Ok("Config deleted");
        }

        [HttpPost("v1/configs")]
        public async Task<IActionResult> createConfig([FromBody] ConfigsPostRequest request)
        {
            var config = new Config
            { 
                Name = request.name,
                Value = request.value,
                StrategyInstanceId = request.instanceId?? -1
            };

           await _configService.createConfig(config);
          
            return Ok(config);
        }

        [HttpPut("v1/configs")]
        public async Task<IActionResult> updateConfig(ConfigsPutRequest request)
        {
            var config = new Config
            {
                Id = request.id?? -1,
                Name = request.name,
                Value = request.value,
                StrategyInstanceId = request.instanceId ?? -1
            };

            var wasUpdated = await _configService.updateConfig(config);

            if (!wasUpdated)
            {
                return NotFound();
            }

            return Ok(config);
        }


    }
}
