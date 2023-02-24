namespace SvSupportSales.Commons
{
    public class ApiMessage
    {
        public string? Type { get; set; }
        public String? Message { get; set; }
        public ApiMessage() { }

        public ApiMessage(string? type, string? message)
        {
            Type = type;
            Message = message;
        }
    }
}
