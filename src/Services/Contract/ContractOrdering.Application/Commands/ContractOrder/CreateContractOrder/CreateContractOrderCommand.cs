using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace YunStorm.MoCRM.ContractOrdering.Application.Commands.ContractOrder.CreateContractOrder
{
    public class CreateContractOrderCommand
        : IRequest<long>
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
    }
}
