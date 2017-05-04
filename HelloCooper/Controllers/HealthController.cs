using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace HelloCooper.Controllers
{
    [Route("api/[controller]")]
    public class HealthController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "I'm healthy!" ;
        }
    }
}
