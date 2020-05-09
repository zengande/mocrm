using System;
using System.Collections.Generic;
using System.Text;
using YunStorm.MoCRM.BuildingBlocks.Domain;

namespace YunStorm.MoCRM.Contract.Domain.ContractAggregate
{
    public class Contract :
        Entity, IAggregateRoot
    {
        public string Number { get; private set; }
        public string Name { get; private set; }
        public decimal ContractCost { get; private set; }
        public decimal ContractPrice { get; private set; }
        public long CustomerId { get; private set; }
        public string CustomerName { get; private set; }
        public string CreatorId { get; private set; }

        private List<ContractProduct> _contractProducts;
        public IReadOnlyCollection<ContractProduct> ContractProducts 
            => _contractProducts?.AsReadOnly();

        public PaymentMethod PaymentMethod { get; private set; }
        private int _paymentMethodId;

        public ContractStatus ContractStatus { get; private set; }
        private int _contractStatusId;

        public Contract(string number, string name, decimal contractCost)
        {
            Number = number;
            Name = name;
            ContractCost = contractCost;
        }

        protected Contract() { }
    }
}
