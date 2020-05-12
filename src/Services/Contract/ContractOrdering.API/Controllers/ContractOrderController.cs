using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YunStorm.MoCRM.ContractOrdering.Application.Commands.ContractOrder.CreateContractOrder;

namespace ContractOrdering.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractOrderController
        : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContractOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody]CreateContractOrderCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
