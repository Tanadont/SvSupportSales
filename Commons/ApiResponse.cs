using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SvSupportSales.Commons
{
    public class ApiResponse
    {
        public DateTime? TimeStamp { get; set; }
        public int Status { get; set; }
        public List<ApiMessage>? Messages { get; set; }
        public dynamic? Data { get; set; }

        public ApiResponse() { }

        public ApiResponse(int status, List<ApiMessage>? messages, dynamic data)
        {
            TimeStamp = DateTime.Now;
            Status = status;
            Messages = messages;
            Data = data;
        }

        public ApiResponse(int status, List<ApiMessage>? messages)
        {
            TimeStamp = DateTime.Now;
            Status = status;
            Messages = messages;
        }
    }
}
