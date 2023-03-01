using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SvSupportSales.Models;
using SvSupportSales.Services;

namespace SvSupportSales.Controllers
{
    [Route("v1/support-sales/master")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterService masterService;

        public MasterController(IMasterService masterService)
        {
            this.masterService = masterService;
        }

        /// <summary>
        /// AutoComplete 
        /// </summary>
        [HttpGet("sales-name")]
        public IActionResult SalesName([FromQuery] AutoCompleteModel filter)
        {
            return Ok(masterService.SalesNameAutoComplete(filter));
        }

        /// <summary>
        /// AutoComplete
        /// </summary>
        [HttpGet("branch-name")]
        public IActionResult BranchName([FromQuery] AutoCompleteModel filter)
        {
            return Ok(masterService.BranchNameAutoComplete(filter));
        }

        /// <summary>
        /// DropDown
        /// </summary>
        [HttpGet("register-type")]
        public IActionResult RegisterType()
        {
            return Ok(masterService.DropDownRegisterType());
        }

        /// <summary>
        /// AutoComplete 
        /// </summary>
        [HttpGet("structure-team-name")]
        public IActionResult SalesStructureTeamName([FromQuery] AutoCompleteModel filter)
        {
            return Ok(masterService.SalesStructureTeamNameAutoComplete(filter));
        }

        /// <summary>
        /// DropDown
        /// </summary>
        [HttpGet("position-name")]
        public IActionResult DropDownPosition([FromQuery] AutoCompleteModel filter)
        {
            return Ok(masterService.PositionAutoComplete(filter));
        }

        /// <summary>
        /// AutoComplete 
        /// </summary>
        [HttpGet("document-status-name")]
        public IActionResult DocumentStatus([FromQuery] AutoCompleteModel filter)
        {
            return Ok(masterService.DropDownDocumentStatus(filter));
        }

        /// <summary>
        /// DropDown
        /// </summary>
        [HttpGet("sale-status")]
        public IActionResult SaleStatus()
        {
            return Ok(masterService.DropDownSaleStatus());
        }

        /// <summary>
        /// AutoComplete 
        /// </summary>
        [HttpGet("supervisor-name")]
        public IActionResult SupervisorName([FromQuery] AutoCompleteModel filter)
        {
            return Ok(masterService.SupervisorNameAutoComplete(filter));
        }

    }
}
