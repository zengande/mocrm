using System;
using System.Collections.Generic;
using System.Text;
using YunStorm.MoCRM.BuildingBlocks.Domain;

namespace YunStorm.MoCRM.Contract.Domain.ContractAggregate
{
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
