using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SvSupportSales.Models;
using SvSupportSales.Services;

namespace SvSupportSales.Controllers
{
    [Route("v1/support-sales")]
    [ApiController]
    public class SalesProfileController : ControllerBase
    {
        private readonly ISalesProfileService salesProfileService;

        public SalesProfileController(ISalesProfileService salesProfileService)
        {
            this.salesProfileService = salesProfileService;
        }

        /// <summary>
        /// Search Sales Profiles
        /// </summary>
        [HttpGet("sales-profiles")]
        public IActionResult Search([FromQuery] QuerySalesProfile query)
        {
            return Ok(salesProfileService.Search(query));
        }

    }
}
