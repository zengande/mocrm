using System;
using System.Collections.Generic;
using System.Text;

namespace YunStorm.MoCRM.BuildingBlocks.Application.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }
    }

    public class DefaultCurrentUserService : ICurrentUserService
    {
        public string UserId => Guid.Empty.ToString();
    }

}
