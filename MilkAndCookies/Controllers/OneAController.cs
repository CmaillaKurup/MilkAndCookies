using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MilkAndCookies.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public string Get()
        {
            Console.WriteLine("pick your favorite milkshake ");
            Console.WriteLine("A: " + Flavor[0] + ", B: " + Flavor[1] + ", C: " + Flavor[2] + " or D: " + Flavor[3]);
            String userInput = Console.ReadLine();

            if (userInput == "A" || userInput == "a")
            {
                //Response.

                Console.WriteLine("you picked " + Flavor[0]);
            }
            if (userInput == "B" || userInput == "b")
            {
                Console.WriteLine("you picked " + Flavor[1]);
            }
            if (userInput == "C" || userInput == "c")
            {
                Console.WriteLine("you picked " + Flavor[2]);
            }
            if (userInput == "D" || userInput == "d")
            {
                Console.WriteLine("you picked " + Flavor[3]);
            }
            Response.Cookies.Append("favoriteMilkshake", userInput);
            return userInput;
            
        }
        
        
    }
}