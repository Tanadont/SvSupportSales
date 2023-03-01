using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using Swashbuckle.AspNetCore.Annotations;

namespace SvSupportSales.Models
{
    //แยก skip limit textSearch 
    public class QuerySalesProfile : Pagination
    {
        public string? CitizenId { get; set; }

        public List<int>? BranchIds { get; set; }

        public int? RegisterType { get; set; }

        public string? SalesStructureTeamId { get; set; }

        public string? Position { get; set; }

        public string? DocumentStatusCode { get; set; }

        public List<string>? SaleStatus { get; set; }

        public string? SupervisorCitizenId { get; set; }

        public DateTime? DocumentStartDate { get; set; }

        public DateTime? DocumentEndDate { get; set; }

        /*
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum Order
        {
            [EnumMember(Value = "documentNo")]
            documentNo,
            [EnumMember(Value = "salesName")]
            salesName,
            [EnumMember(Value = "documentDate")]
            documentDate,
            [EnumMember(Value = "documentStatusCode")]
            documentStatusCode,
            [EnumMember(Value = "saleStatus")]
            saleStatus,
            [EnumMember(Value = "updatedDate")]
            updatedDate,
        }*/
        /// <summary>
        /// orderBy >> documentNo,salesName,documentDate,documentStatusCode,saleStatus,updatedDate
        /// </summary>
        public new string? OrderBy { get; set; }
    }
}
