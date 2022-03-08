using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MilkAndCookies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MilkshakeController : ControllerBase
    {
        private readonly ILogger<MilkshakeController> _logger;
        
        public MilkshakeController(ILogger<MilkshakeController> logger)
        {
            _logger = logger;
        }
        //my parameter "flavor" is also the parameter I am sending to my url
        [HttpGet]
        public string Get(string flavor)
        {
            //This is setting the expire time to 5 minutes
            var co = new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(5)
            };
            
            //This is my cookie
            Response.Cookies.Append("favoriteMilkshake", flavor, co);
            
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