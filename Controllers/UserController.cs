
using System.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SvSupportSales.Commons;

using SvSupportSales.Models;
using SvSupportSales.Resources;
using SvSupportSales.Services;

namespace SvSupportSales.Controllers
{
    [ApiController]
    [Route("/um/api/")]
    public class UserController : AbsController
    {
        private readonly IUmService umService;
        private readonly IStringLocalizer<Resource> localizer;

        public UserController(IStringLocalizer<Resource> localizer, IUmService umService)
        {
            this.umService = umService;
            this.localizer = localizer;
        }
        

        [HttpGet("v1/{id}/user-info")]
        public IActionResult userInfo(int id)
        {
            //return Ok(umService.GetUserDataById(id));
            return Ok();
        }

        [HttpPost("v1/save")]
        public IActionResult createUser()
        {
            string localizedString = localizer["test"].Value;
            Console.WriteLine(localizer["test"]);
            /*
            bool isvalid = TryValidateModel(data);
            if (!isvalid)
            {
                return Ok(BadRequestResponse(ModelState.Values));                
            }*/
            return Ok();
        }
    }   
}
