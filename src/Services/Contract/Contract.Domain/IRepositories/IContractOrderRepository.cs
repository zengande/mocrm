using System;
using System.Collections.Generic;
using System.Text;
using YunStorm.MoCRM.BuildingBlocks.Domain;
using YunStorm.MoCRM.ContractOrdering.Domain.Entities;

namespace YunStorm.MoCRM.ContractOrdering.Domain.IRepositories
{
    public interface IContractOrderRepository
        : IRepository<ContractOrder>
    {
    }
}
