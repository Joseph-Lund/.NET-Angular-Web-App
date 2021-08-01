using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net_5.Services;

namespace net_5.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IDapperService _dapper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDapperService dapper)
        {
            _logger = logger;
            _dapper = dapper;
        }

        [HttpGet(nameof(Get))]  
        public async Task<List<WeatherForecast>> Get()  
        {  
            var result = await Task.FromResult(_dapper.GetAll<WeatherForecast>("spGetWeatherForecasts", null));  
            return result;  
        }  
    }
}
