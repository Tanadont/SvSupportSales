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

        public TransSaleRegister? View(int id);
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
            if(query.Search != null && query.Search.Trim().Length > 0)
            {
                queryCondition.Append(
                    $" AND ( concat(UPPER(tsr.prefix),' ',UPPER(tsr.firstName),' ',UPPER(tsr.lastName)) LIKE '%{query.Search.ToUpper()}%' " +
                    $" OR tsr.telephone LIKE '%{query.Search}%' " +
                    $" OR tsr.document_no LIKE '%{query.Search}%' " +
                    $" OR tsr.citizenId LIKE '%{query.Search}%' ) ");
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
            //ทำเป็น list sortBy
            //ทำ sort condition
            string orderString = "tsr.updateddate";
            switch (query.OrderBy)
            {
                case "documentNo":
                    orderString = "tsr.documentno";
                    break;
                case "salesName":
                    orderString = "concat(tsr.prefix,' ',tsr.firstName,' ',tsr.lastName)";
                    break;
                case "documentDate":
                    orderString = "tsr.documentdate";
                    break;
                case "documentStatusCode":
                    orderString = "tsr.documentstatuscode";
                    break;
                case "saleStatus":
                    orderString = "tsr.salestatus";
                    break;
                case "updatedDate":
                    orderString = "tsr.updateddate";
                    break;
            }
            queryCondition.AppendFormat("ORDER BY {0} {1}", orderString, query.SortBy);

            return context.TransSaleRegisters.FromSqlRaw(queryCondition.ToString()).ToList(); ;
        }

        public TransSaleRegister? View (int id)
        {
            return context.TransSaleRegisters.Find(id);
        }
    }
}
