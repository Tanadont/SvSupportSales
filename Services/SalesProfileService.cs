using System.Diagnostics;
using System.Linq;
using Amazon.Runtime.Internal.Transform;
using Microsoft.AspNetCore.Mvc;
using SvSupportSales.Commons;
using SvSupportSales.Entities;
using SvSupportSales.Models;
using SvSupportSales.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SvSupportSales.Services
{
    public interface ISalesProfileService
    {
        ApiResponse search(QuerySalesProfile query);
    }
    public class SalesProfileService : ISalesProfileService
    {

        private ISalesProfileRepository salesProfileRepository;

        public SalesProfileService(ISalesProfileRepository salesProfileRepository)
        {
            this.salesProfileRepository = salesProfileRepository;
        }

        public ApiResponse search(QuerySalesProfile query)
        {
            LinkedList<Dictionary<string, object>> dataList = new LinkedList<Dictionary<string, object>>();
            List<TransSaleRegister>? totalRecords = salesProfileRepository.SearchTransSaleRegister(query);
            if(totalRecords != null && totalRecords.Count > 0)
            {
                var result = totalRecords.Skip(query.Limit * query.Skip).Take(query.Limit).ToList();
                int count = (query.Limit*query.Skip)+1;
                foreach(var eachResult in result)
                {
                    var data = new Dictionary<string, object>()
                    {
                        {"no",count },
                        {"registerId", eachResult.Salesregisterid },
                        {"documentNo", eachResult.Documentno },
                        {"branchName", eachResult.Branchname },
                        {"registerType", (eachResult.Registertype == 1)? "Normal": (eachResult.Registertype == 2)? "Fast Track" : "-" },
                        {"salesType", eachResult.Salestype },
                        {"citizenId", eachResult.Citizenid },
                        {"salesName", eachResult.Prefix + " " + eachResult.Firstname + " " + eachResult.Lastname},
                        {"salesstructureteamcode", eachResult.Salesstructureteamcode },
                        {"position", eachResult.Position },
                        {"telephone", eachResult.Telephone },
                        {"documentDate", eachResult.Documentdate },
                        {"documentStatus", eachResult.Documentstatuscode },
                        {"salesStatus", eachResult.Salestatus },
                        {"updatedBy", eachResult.Updatedby },
                        {"updatedDate", eachResult.Updateddate },
                    };
                    count++;
                    dataList.AddLast(data);
                }
            }
            return new ApiResponse(StatusCodes.Status200OK, null, dataList);
        }
    }
}
