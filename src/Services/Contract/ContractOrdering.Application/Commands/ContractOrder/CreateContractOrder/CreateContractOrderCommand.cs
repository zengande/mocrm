using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace YunStorm.MoCRM.ContractOrdering.Application.Commands.ContractOrder.CreateContractOrder
{
    public class CreateContractOrderCommand 
        : IRequest<long>
    {
        public string Name { get; private set; }

        public CreateContractOrderCommand()
        {

        }
        public CreateContractOrderCommand(string name)
        {

        }
    }
}
