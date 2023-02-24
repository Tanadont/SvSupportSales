using System.Diagnostics;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using SvSupportSales.Entities;
using SvSupportSales.Models;

namespace SvSupportSales.Repositories
{

    public interface ISalesProfileRepository
    {
        List<TransSaleRegister>? SearchTransSaleRegister(QuerySalesProfile query);
    }

    public class SalesProfileRepository : ISalesProfileRepository
    {
        private DataContext context;

        public SalesProfileRepository(DataContext context)
        {
            this.context = context;
        }

        public List<TransSaleRegister>? SearchTransSaleRegister(QuerySalesProfile query)
        {
            StringBuilder queryCondition = new StringBuilder();
            queryCondition.Append("SELECT * FROM trans_sale_register as tsr WHERE 1 = 1 ");
            if(query.textSearch!= null && query.textSearch.Trim().Length > 0)
            {
                queryCondition.Append(
                    $" AND ( concat(UPPER(tsr.prefix),' ',UPPER(tsr.firstName),' ',UPPER(tsr.lastName)) LIKE '%{query.textSearch.ToUpper()}%' " +
                    $" OR tsr.telephone LIKE '%{query.textSearch}%' " +
                    $" OR tsr.document_no LIKE '%{query.textSearch}%' " +
                    $" OR tsr.citizenId LIKE '%{query.textSearch}%' ) ");
            }
            if (query.CitizenId != null)
            {
                queryCondition.Append($" AND tsr.citizenid = '{query.CitizenId}' ");
            }
            if(query.BranchIds != null && query.BranchIds.Count > 0)
            {
                queryCondition.AppendFormat(" AND tsr.branchid IN ({0})",string.Join(",",query.BranchIds));
            }
            if(query.RegisterType!= null)
            {
                queryCondition.Append($"AND tsr.registertype = {query.RegisterType} ");
            }
            if(query.SalesStructureTeamId != null)
            {
                queryCondition.Append($"AND tsr.salesstructureteamid = '{query.SalesStructureTeamId}' ");
            }
            if(query.Position != null)
            {
                queryCondition.Append($"AND tsr.position = '{query.Position}' ");
            }
            if(query.DocumentStatusCode!= null)
            {
                queryCondition.Append($"AND tsr.documentstatuscode = '{query.DocumentStatusCode}' ");
            }
            if (query.SaleStatus != null)
            {
                queryCondition.AppendFormat("AND tsr.salestatus IN ({0}) ", string.Join(",", query.SaleStatus));
            }
            if(query.SupervisorCitizenId != null)
            {
                queryCondition.Append($"AND tsr.supervisorcitizenid = '{query.SupervisorCitizenId}' ");
            }
            if(query.DocumentStartDate!= null)
            {
                queryCondition.Append($"AND tsr.documentdate >= {query.DocumentStartDate} ");
            }
            if (query.DocumentEndDate != null)
            {
                queryCondition.Append($"AND tsr.documentdate <= {query.DocumentEndDate} ");
            }
            
            //ทำ sort condition
            string sortString = "tsr.updateddate";
            switch (query.SortBy.ToString())
            {
                case "documentNo":
                    sortString = "tsr.documentno";
                    break;
                case "salesName":
                    sortString = "concat(tsr.prefix,' ',tsr.firstName,' ',tsr.lastName)";
                    break;
                case "documentDate":
                    sortString = "tsr.documentdate";
                    break;
                case "documentStatusCode":
                    sortString = "tsr.documentstatuscode";
                    break;
                case "saleStatus":
                    sortString = "tsr.salestatus";
                    break;
                case "updatedDate":
                    sortString = "tsr.updateddate";
                    break;
            }
            queryCondition.AppendFormat("ORDER BY {0} {1}", sortString, query.OrderBy);

            return context.TransSaleRegisters.FromSqlRaw(queryCondition.ToString()).ToList(); ;
        }
    }
}
