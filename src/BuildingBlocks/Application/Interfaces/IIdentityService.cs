using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YunStorm.MoCRM.BuildingBlocks.Application.Models;

namespace YunStorm.MoCRM.BuildingBlocks.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }

    public class DefaultIdentityService : IIdentityService
    {
        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
            => (Result.Failure(new[] { "NotImplemented" }), Guid.Empty.ToString());

        public async Task<Result> DeleteUserAsync(string userId) => Result.Failure(new[] { "NotImplemented" });

        public async Task<string> GetUserNameAsync(string userId) => Guid.Empty.ToString();
    }
}
