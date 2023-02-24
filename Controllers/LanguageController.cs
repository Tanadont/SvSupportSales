using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using SvSupportSales.Services;

namespace SvSupportSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private LanguageService _localization;

        public LanguageController(LanguageService localiaztion)
        {
            _localization = localiaztion;
        }

        [HttpGet("lang")]
        public IActionResult Index([FromHeader(Name = "Accept-Language")] string lang)
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            return Ok(_localization.Getkey());
        }
    }
}
