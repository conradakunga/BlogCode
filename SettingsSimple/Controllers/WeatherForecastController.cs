using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace SettingsSimple.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        Settings _settings;
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<Settings> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("The values are {bool} {int} {string}",
             _settings.BooleanValue, _settings.IntValue, _settings.StringValue);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json", optional: false)
                .Build();

     

            var r = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = r.Next(-20, 55),
                Summary = Summaries[r.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}