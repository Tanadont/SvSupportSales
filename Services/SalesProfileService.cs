using System.Diagnostics;
using System.Linq;
using Amazon.Runtime.Internal.Transform;
using Microsoft.AspNetCore.Mvc;
using SvSupportSales.Commons;
using SvSupportSales.Entities;
using SvSupportSales.Models;
using SvSupportSales.Models.ResponseModel;
using SvSupportSales.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SvSupportSales.Services
{
    public interface ISalesProfileService
    {
        ApiResponseWithPage Search(QuerySalesProfile query);
    }
    public class SalesProfileService : ISalesProfileService
    {

        private ISalesProfileRepository salesProfileRepository;

        public SalesProfileService(ISalesProfileRepository salesProfileRepository)
        {
            this.salesProfileRepository = salesProfileRepository;
        }
     
        public ApiResponseWithPage Search(QuerySalesProfile query)
        {
            ApiResponseWithPage responseWithPage = new ApiResponseWithPage();
            LinkedList<SearchResponseModel> responseList = new LinkedList<SearchResponseModel>();
            List<TransSaleRegister>? totalRecords = salesProfileRepository.SearchTransSaleRegister(query);
            if(totalRecords != null && totalRecords.Count > 0)
            {
                var result = totalRecords.Skip(query.PageSize * query.PageNo).Take(query.PageSize).ToList();
                int count = (query.PageSize * query.PageNo) +1;
                foreach(var eachResult in result)
                {
                    SearchResponseModel responseModel = new SearchResponseModel
                    {
                        No = count,
                        SalesRegisterId = eachResult.Salesregisterid,
                        DocumentNo = eachResult.Documentno,
                        BranchName = eachResult.Branchname,
                        RegisterTypeName = (eachResult.Registertype == 1) ? "Normal" : (eachResult.Registertype == 2) ? "Fast Track" : "-",
                        SalesType = eachResult.Salestype,
                        CitizenId = eachResult.Citizenid,
                        SalesName = eachResult.Prefix + " " + eachResult.Firstname + " " + eachResult.Lastname,
                        TeamId = new List<int?> { eachResult.Salesstructureteamid },
                        //responseModel.PositionCode = "";
                        Telephone = eachResult.Telephone,
                        DocumentDate = eachResult.Documentdate == null ? " - " : eachResult.Documentdate?.ToString("dd/MM/yyyy"),
                        DocumentStatus = eachResult.Documentstatuscode,
                        SaleStatus = eachResult.Salestatus,
                        UpdatedBy = eachResult.Updatedby,
                        UpdatedDate = eachResult.Updateddate == null ? " - " : eachResult.Updateddate?.ToString("dd/MM/yyyy")
                    };
                    count++;
                    responseList.AddLast(responseModel);
                }
            }
            responseWithPage.CurrentPage = query.PageNo;
            responseWithPage.PageSize = query.PageSize;
            responseWithPage.TotalRecord = totalRecords.Count;
            responseWithPage.TotalPage = totalRecords.Count / query.PageSize;
            responseWithPage.Status = StatusCodes.Status200OK;
            responseWithPage.Data = responseList;
            return responseWithPage;
        }

        public ApiResponse View (int id)
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            /*TransSaleRegister? data = salesProfileRepository.View(id);
            if (data == null)
            {
                throw new Exception($"not found id: {id}");
            }
            else
            {
                response.Add("transSaleRegisterId", data.Salesregisterid);
                response.Add("documentno", data.Documentno);
                //response.Add("documentDate", data.Documentdate == null ? " - " : data.Documentdate.ToString("DD/MM/yyyy"));
                
            }*/
            return new ApiResponse(StatusCodes.Status200OK, null, response);
        }
    }
}
