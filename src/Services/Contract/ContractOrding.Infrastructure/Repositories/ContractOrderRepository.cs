using System;
using System.Collections.Generic;
using System.Text;
using YunStorm.MoCRM.BuildingBlocks.Domain;
using YunStorm.MoCRM.ContractOrdering.Domain.IRepositories;

namespace YunStorm.MoCRM.ContractOrding.Infrastructure.Repositories
{
    public class ContractOrderRepository
        : IContractOrderRepository
    {
        private readonly ContractOrderingDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public ContractOrderRepository(ContractOrderingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
