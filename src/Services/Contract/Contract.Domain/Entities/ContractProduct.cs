using System;
using System.Collections.Generic;
using System.Text;
using YunStorm.MoCRM.BuildingBlocks.Domain;

namespace YunStorm.MoCRM.ContractOrdering.Domain.Entities
{
    /// <summary>
    /// 合同关联产品
    /// </summary>
    public class ContractProduct
        : Entity
    {
        public long ProductId { get; private set; }
        public string ProductName { get; private set; }

        public ContractProduct(long productId, string productName)
        {
            ProductId = productId;
            ProductName = productName;
        }

        protected ContractProduct()
        {

        }
    }
}
