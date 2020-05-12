using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YunStorm.MoCRM.ContractOrdering.Application.Commands.ContractOrder.CreateContractOrder
{
    public class CreateContractOrderCommandHandler : IRequestHandler<CreateContractOrderCommand, long>
    {
        public async Task<long> Handle(CreateContractOrderCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(600);
            return 0L;
        }
    }
}
