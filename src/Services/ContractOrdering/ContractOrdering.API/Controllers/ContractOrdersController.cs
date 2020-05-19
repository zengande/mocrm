using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YunStorm.MoCRM.ContractOrdering.Application.Commands.ContractOrder.CreateContractOrder;

namespace YunStorm.MoCRM.ContractOrdering.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ContractOrdersController
        : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContractOrdersController(IMediator mediator)
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
