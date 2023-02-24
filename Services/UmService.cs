using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SvSupportSales.Commons;
using SvSupportSales.Entities;
using SvSupportSales.Models;
using SvSupportSales.Repositories;

namespace SvSupportSales.Services
{
    public interface IUmService
    {/*
        ApiResponse GetUserDataById([FromQuery] int id);*/
    }

 
    public class UmService : IUmService
    {/*
        private IUmRepository umRepository;

        public UmService(IUmRepository umRepository)
        {
            this.umRepository = umRepository;
        }

        public ApiResponse GetUserDataById([FromQuery] int id)
        {
            MasUser? user = umRepository.FindById(id);
            if(Object.Equals(user, null)) { throw new ServiceException($"Not found user with id {id}"); }
            else
            {
                User data = new User()
                {
                    UserId = user.UserId,
                    Position = user.Position,
                    Prefix = user.Prefix,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Name = $"{user.FirstName} {user.LastName}",
                    NickName= user.NickName,
                    Telephone=user.Telephone,
                    BranchName=user.BranchName,
                    RegionName=user.RegionName,
                    CitizenId=user.CitizenId
                };

                return new ApiResponse(StatusCodes.Status200OK, null, data);
            }
        }*/

    }
}
