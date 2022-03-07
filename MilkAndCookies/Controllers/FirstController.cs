using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MilkAndCookies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FirstController : ControllerBase
    {
        private readonly ILogger<FirstController> _logger;

        public FirstController(ILogger<FirstController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public string GetLetter(string inputLetter)
        {
            //This is setting the expire time to 5 minutes
            var co = new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(-5)
            };
            
            //This is my cookie
            Response.Cookies.Append("inputLetter", inputLetter, co);
            
            return inputLetter;
        }
        
        [HttpGet]
        [Route("[action]")]
        public string GetLetterFromCookie()
        {
            //Here I am requesting my cookie data in a return
            return Request.Cookies["inputLetter"];
        }
    }
}