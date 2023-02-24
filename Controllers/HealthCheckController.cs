using Microsoft.AspNetCore.Mvc;

namespace SvSupportSales.Controllers
{
    [ApiController]
    [Route("/health")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult HealthCheck()
        {
            return Ok("Service Support-Sales Started.");
        }
    }
}

