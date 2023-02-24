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

        [HttpGet("sales-name-autocomplete")]
        public IActionResult DropDownSalesNameAutoComplete(string salesName, int limit)
        {
            return Ok(masterService.DropDownSalesNameAutoComplete(salesName, limit));
        }

        [HttpGet("branch-name-autocomplete")]
        public IActionResult DropDownBranchNameAutoComplete(string branchName, int limit)
        {
            return Ok(masterService.DropDownBranchNameAutoComplete(branchName, limit));
        }

        [HttpGet("register-type-dropdown")]
        public IActionResult DropDownRegisterType()
        {
            return Ok(masterService.DropDownRegisterType());
        }

        [HttpGet("structure-team-name-autocomplete")]
        public IActionResult DropDownSalesStructureTeamNameAutoComplete(string salesStructureTeamName, int limit)
        {
            return Ok(masterService.DropDownSalesStructureTeamNameAutoComplete(salesStructureTeamName, limit));
        }

        [HttpGet("position-name-autocomplete")]
        public IActionResult DropDownPositionAutoComplete(string positionName, int limit)
        {
            return Ok(masterService.DropDownPositionAutoComplete(positionName, limit));
        }

        [HttpGet("document-status-name-autocomplete")]
        public IActionResult DropDownDocumentStatusAutoComplete(string documentStatusName, int limit)
        {
            return Ok(masterService.DropDownDocumentStatusAutoComplete(documentStatusName, limit));
        }

        [HttpGet("sale-status-dropdown")]
        public IActionResult DropDownSaleStatus()
        {
            return Ok(masterService.DropDownSaleStatus());
        }

        [HttpGet("supervisor-name-autocomplete")]
        public IActionResult DropDownSupervisorNameAutoComplete(string supervisorName, int limit)
        {
            return Ok(masterService.DropDownSupervisorNameAutoComplete(supervisorName, limit));
        }

    }
}
