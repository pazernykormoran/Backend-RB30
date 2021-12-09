using Binance.Net;
using Binance.Net.Enums;
using Microsoft.AspNetCore.Mvc;
using RetireBefore30.Contracts.Configs;
using RetireBefore30.Models;
using RetireBefore30.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoExchange.Net.ExchangeInterfaces;

namespace RetireBefore30.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ConfigController : Controller
    {
        private readonly IConfigService _configService;
        //List<IBinanceKline> lineData;
        private IExchangeClient client;

        public ConfigController(IConfigService configService)
        {
            _configService = configService;
            client = new BinanceClient();
            
            //iLogger.LogInformation(candles);
        }

        [HttpGet("v1/candles")]
        public async Task<IActionResult> getCandles([FromQuery] CandlesGetRequest request)
        {

            long second = 10000000;
            long minute = second * 60 ;
            long period;
            switch (request.period)
            {
                case "1m": period = minute; break;
                case "3m": period = minute*3; break;
                case "5m": period = minute*5; break;
                case "15m": period = minute*15; break;
                case "30m": period = minute*30; break;
                case "1h": period = minute*60; break;
                case "2h": period = minute*60*2; break;
                case "4h": period = minute * 60 * 4; break;
                case "6h": period = minute * 60 * 6; break;
                case "8h": period = minute * 60 * 8; break;
                case "12h": period = minute * 60 * 12; break;
                case "1d": period = minute * 60 * 24; break;
                case "3d": period = minute * 60 * 24 * 3; break;
                case "1w": period = minute * 60 * 24 * 7; break;
                case "1M": period = minute * 60 * 24 * 30; break;
                default: period = minute * 60 * 24; break;
            }
            var timespan = new TimeSpan(period);

            DateTime fromDate;
            DateTime toDate;
            if (request.startTime != -1 && request.endTime != -1)
            {
                fromDate = DateTimeOffset.FromUnixTimeMilliseconds(request.startTime).UtcDateTime;
                toDate = DateTimeOffset.FromUnixTimeMilliseconds(request.endTime).UtcDateTime;
                return Ok(await client.GetKlinesAsync(request.symbol, timespan, fromDate, toDate, limit: request.limit));
            }
            else
            {
                return Ok(await client.GetKlinesAsync(request.symbol, timespan, limit: request.limit));
            }
            
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
