using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YunStorm.MoCRM.ContractOrdering.Application.Commands.ContractOrder.CreateContractOrder;

namespace YunStorm.MoCRM.ContractOrdering.Application.Validations.ContractOrder
{
    public class CreateContractOrderCommandValidator
        : AbstractValidator<CreateContractOrderCommand>
    {
        public CreateContractOrderCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty();
        }
    }
}
