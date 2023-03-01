using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Services;
using SvSupportSales.Commons;
using SvSupportSales.Entities;
using SvSupportSales.Models;
using SvSupportSales.Repositories;

namespace SvSupportSales.Services
{
    public interface IMasterService
    {
        public ApiResponse SalesNameAutoComplete(AutoCompleteModel filter);
        public ApiResponse BranchNameAutoComplete(AutoCompleteModel filter);
        public ApiResponse DropDownRegisterType();
        public ApiResponse SalesStructureTeamNameAutoComplete(AutoCompleteModel filter);
        public ApiResponse PositionAutoComplete(AutoCompleteModel filter);
        public ApiResponse DropDownDocumentStatus(AutoCompleteModel filter);
        public ApiResponse DropDownSaleStatus();
        public ApiResponse SupervisorNameAutoComplete(AutoCompleteModel filter);
    }
    public class MasterService : IMasterService
    {
        private IMasterRepository masterRepository;

        public MasterService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public ApiResponse BranchNameAutoComplete(AutoCompleteModel filter)
        {
            List<DropDownResult> resultList = new List<DropDownResult>();
            List<MasBranch>? dataList = masterRepository.FindMasBranch(filter.Search, filter.Limit);
            if (dataList != null && dataList.Count > 0)
            {
                foreach (MasBranch data in dataList)
                {
                    DropDownResult result = new DropDownResult();
                    result.Value = data.Branchid;
                    result.Label = data.Name;
                    resultList.Add(result);
                };
            }
            return new ApiResponse(StatusCodes.Status200OK, null, resultList);
        }

        public ApiResponse DropDownDocumentStatus(AutoCompleteModel filter)
        {
            List<DropDownResult> resultList = new List<DropDownResult>();
            List<MasDocumentStatus>? dataList = masterRepository.FindMasDocumentStatus(filter.Search, filter.Limit);
            if (dataList != null && dataList.Count > 0)
            {
                foreach (MasDocumentStatus data in dataList)
                {
                    DropDownResult result = new DropDownResult();
                    result.Value = data.Documentstatuscode;
                    result.Label = data.Documentstatusname;
                    resultList.Add(result);
                };
            }
            return new ApiResponse(StatusCodes.Status200OK, null, resultList);
        }

        public ApiResponse PositionAutoComplete(AutoCompleteModel filter)
        {
            List<DropDownResult> resultList = new List<DropDownResult>();
            List<MasSalesPosition>? dataList = masterRepository.FindMasSalesPosition(filter.Search, filter.Limit);
            if (dataList != null && dataList.Count > 0)
            {
                foreach (MasSalesPosition data in dataList)
                {
                    DropDownResult result = new DropDownResult();
                    result.Value = data.Code;
                    result.Label = data.Name;
                    resultList.Add(result);
                };
            }
            return new ApiResponse(StatusCodes.Status200OK, null, resultList);
        }

        public ApiResponse DropDownRegisterType()
        {
            List<DropDownResult> resultList = new List<DropDownResult>
            {
                new DropDownResult {Value = 1, Label = "Normal"},
                new DropDownResult {Value = 2, Label = "Fast Track"},
            };
            return new ApiResponse(StatusCodes.Status200OK, null, resultList);
        }

        public ApiResponse SalesNameAutoComplete(AutoCompleteModel filter)
        {
            List<DropDownResult> resultList = new List<DropDownResult>();
            List<MasSalesStructure>? dataList = masterRepository.FindMasSalesStructure(filter.Search, false, filter.Limit);
            if(dataList != null && dataList.Count> 0)
            {
                foreach (MasSalesStructure data in dataList)
                {
                    DropDownResult result = new DropDownResult();
                    result.Value = data.Citizenid;
                    result.Label = data.Prefix + " " + data.Firstname + " " + data.Lastname;
                    resultList.Add(result);
                };
            }
            return new ApiResponse(StatusCodes.Status200OK, null, resultList);
        }

        public ApiResponse SalesStructureTeamNameAutoComplete(AutoCompleteModel filter)
        {
            List<DropDownResult> resultList = new List<DropDownResult>();
            List<MasSalesTeam>? dataList = masterRepository.FindMasSalesTeam(filter.Search, filter.Limit);
            if (dataList != null && dataList.Count > 0)
            {  
                foreach (MasSalesTeam data in dataList)
                {
                    DropDownResult result = new DropDownResult();
                    result.Value = data.Salesstructureteamid;
                    result.Label = data.Salesstructureteamname;
                    resultList.Add(result);
                };
            }
            return new ApiResponse(StatusCodes.Status200OK, null, resultList);
        }

        public ApiResponse DropDownSaleStatus()
        {
            List<DropDownResult> resultList = new List<DropDownResult>
            { 
                new DropDownResult {Value = "Active", Label = "Active"},
                new DropDownResult {Value = "Deactive", Label = "Deactive"},
            };
            return new ApiResponse(StatusCodes.Status200OK, null, resultList);
        }

        public ApiResponse SupervisorNameAutoComplete(AutoCompleteModel filter)
        {
            List<DropDownResult> resultList = new List<DropDownResult>();
            List<MasSalesStructure>? dataList = masterRepository.FindMasSalesStructure(filter.Search, true, filter.Limit);
            if (dataList != null && dataList.Count > 0)
            {
                foreach (MasSalesStructure data in dataList)
                {
                    DropDownResult result = new DropDownResult();
                    result.Value = data.Citizenid;
                    result.Label = data.Prefix + " " + data.Firstname + " " + data.Lastname;
                    resultList.Add(result);
                };
            }
            return new ApiResponse(StatusCodes.Status200OK, null, resultList);
        }
    }
}
