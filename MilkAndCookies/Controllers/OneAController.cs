using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MilkAndCookies.Controllers
{
    public class OneAController : ControllerBase
    {
        private static readonly string[] Flavor = new[]
        {
            "Strawberry", "Vanilla", "Chocolate", "Banana"
        };
        
        private readonly ILogger<OneAController> _logger;

        public OneAController(ILogger<OneAController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Flavor[rng.Next(Flavor.Length)]
                })
                .ToArray();
        }
        
    }
}