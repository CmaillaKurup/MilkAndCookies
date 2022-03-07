using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MilkAndCookies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecondController : ControllerBase
    {
        private readonly ILogger<SecondController> _logger;

        public SecondController(ILogger<SecondController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        [Route("[action]")]
        public string GetLetterFromCookieFirst()
        {
            //Here I am requesting my cookie data in a return
            return Request.Cookies["inputLetter"];
        }
    }
}