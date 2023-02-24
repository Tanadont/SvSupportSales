

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SvSupportSales.Commons
{
    public class ValidationResult
    {
        public static ApiResponse BadRequestResponse(ModelStateDictionary.ValueEnumerable values)
        {
            List<ApiMessage> messages = new List<ApiMessage>();
            foreach (var value in values)
            {
                foreach (var error in value.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                    messages.Add(new ApiMessage("WARNING", error.ErrorMessage));
                }
            }
            return new ApiResponse(StatusCodes.Status400BadRequest, messages, null);
        }
    }
}
