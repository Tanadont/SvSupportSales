using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SvSupportSales.Models
{
    public class Pagination
    {
        public string? Search { get; set; }
        public int PageNo { get; set; } = 0;
        public int PageSize { get; set; } = 50;
        public string? OrderBy { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum Sort
        {
            [EnumMember(Value = "ASC")]
            ASC,
            [EnumMember(Value = "DESC")]
            DESC
        }
        public Sort SortBy { get; set; } = Sort.DESC;
    }
}
