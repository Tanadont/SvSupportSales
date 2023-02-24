using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SvSupportSales.Commons;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Amazon.Auth.AccessControlPolicy;
using Microsoft.Extensions.Localization;

namespace SvSupportSales.Controllers
{
    
    public class AbsController : ControllerBase
    {
        private readonly IStringLocalizer<Resource> localizer;
        [ApiExplorerSettings(IgnoreApi = true)]
        public ApiResponse BadRequestResponse(ModelStateDictionary.ValueEnumerable modelState) {
            List<ApiMessage> messages = new List<ApiMessage>();            
            foreach (var value in modelState)
            {
                foreach (var error in value.Errors)
                {
                    messages.Add(new ApiMessage("WARNING", error.ErrorMessage));
                }
            }
            return new ApiResponse(StatusCodes.Status400BadRequest, messages);
           
        }
    }
}
