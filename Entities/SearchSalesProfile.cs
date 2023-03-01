﻿namespace SvSupportSales.Entities
{
    public class SearchSalesProfile
    {
        public int No { get; set; }
        public string? DocumentNo { get; set; }
        // เอาจาก mas_sales_structure
        public string? BranchName { get; set; }
        public int? RegisterType { get; set; }
        public string? SalesType { get; set; }
        public string? CitizenId { get; set; }
        public string? SalesName { get; set; }
        // เช็คอีกที
        public List<int>? TeamId { get; }
        public List<string>? PositionCode { get; set; }
        public string? Telephone { get; set; }
        public string? DocumentDate { get; set; }
        public string? DocumentStatus { get; set; }
        public string? SaleStatus { get; set; }
        public string? UpdatedBy { get; set; }
        public string? UpdatedDate { get; set; }
    }
}
