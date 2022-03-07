using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MilkAndCookies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MilkshakeController : ControllerBase
    {
        private static readonly string[] Flavor = new[]
        {
            "Strawberry", "Vanilla", "Chocolate", "Banana"
        };
        
        private readonly ILogger<MilkshakeController> _logger;

        public MilkshakeController(ILogger<MilkshakeController> logger)
        {
            _logger = logger;
        }
        //my parameter "flavor" is also the parameter I am sending to my url
        [HttpGet]
        public string Get(string flavor)
        {
            //This is my cookie
            Response.Cookies.Append("favoriteMilkshake", flavor);
            
            return flavor;
        }
        
        [HttpGet]
        [Route("[action]")]
        public string GetFromCookie()
        {
            //Here I am requesting my cookie data in a return
            return Request.Cookies["favoriteMilkshake"];
        }
    }
}