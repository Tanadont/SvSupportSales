using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Services;
using SvSupportSales.Commons;
using SvSupportSales.Entities;
using SvSupportSales.Repositories;

namespace SvSupportSales.Services
{
    public interface IMasterService
    {
        public ApiResponse DropDownSalesNameAutoComplete(string salesName, int limit);
        public ApiResponse DropDownBranchNameAutoComplete(string branchName, int limit);
        public ApiResponse DropDownRegisterType();
        public ApiResponse DropDownSalesStructureTeamNameAutoComplete(string salesStructureTeamName, int limit);
        public ApiResponse DropDownPositionAutoComplete(string positionName, int limit);
        public ApiResponse DropDownDocumentStatusAutoComplete(string documentStatusName, int limit);
        public ApiResponse DropDownSaleStatus();
        public ApiResponse DropDownSupervisorNameAutoComplete(string supervisorName, int limit);
    }
    public class MasterService : IMasterService
    {
        private IMasterRepository masterRepository;

        public MasterService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public ApiResponse DropDownBranchNameAutoComplete(string branchName, int limit)
        {
            List<DropDownResult> resultList = new List<DropDownResult>();
            List<MasBranch>? dataList = masterRepository.FindMasBranch(branchName, limit);
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

        public ApiResponse DropDownDocumentStatusAutoComplete(string documentStatusName, int limit)
        {
            List<DropDownResult> resultList = new List<DropDownResult>();
            List<MasDocumentStatus>? dataList = masterRepository.FindMasDocumentStatus(documentStatusName, limit);
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

        public ApiResponse DropDownPositionAutoComplete(string positionName, int limit)
        {
            List<DropDownResult> resultList = new List<DropDownResult>();
            List<MasSalesPosition>? dataList = masterRepository.FindMasSalesPosition(positionName, limit);
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

        public ApiResponse DropDownSalesNameAutoComplete(string salesName, int limit)
        {
            List<DropDownResult> resultList = new List<DropDownResult>();
            List<MasSalesStructure>? dataList = masterRepository.FindMasSalesStructure(salesName, false, limit);
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

        public ApiResponse DropDownSalesStructureTeamNameAutoComplete(string salesStructureTeamName, int limit)
        {
            List<DropDownResult> resultList = new List<DropDownResult>();
            List<MasSalesTeam>? dataList = masterRepository.FindMasSalesTeam(salesStructureTeamName, limit);
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

        public ApiResponse DropDownSupervisorNameAutoComplete(string supervisorName, int limit)
        {
            List<DropDownResult> resultList = new List<DropDownResult>();
            List<MasSalesStructure>? dataList = masterRepository.FindMasSalesStructure(supervisorName, true, limit);
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
