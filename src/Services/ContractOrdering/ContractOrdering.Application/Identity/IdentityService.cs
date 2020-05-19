using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YunStorm.MoCRM.BuildingBlocks.Application.Interfaces;
using YunStorm.MoCRM.BuildingBlocks.Application.Models;

namespace YunStorm.MoCRM.ContractOrdering.Application.Identity
{
    public class IdentityService : IIdentityService
    {
        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            return (Result.Success(), "0");
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            return Result.Success();
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            return "fake user";
        }
    }
}
