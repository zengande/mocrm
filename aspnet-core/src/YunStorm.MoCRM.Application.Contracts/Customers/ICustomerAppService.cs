using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace YunStorm.MoCRM.Customers
{
    public interface ICustomerAppService : IApplicationService
    {
        Task CreateAsync(CreateCustomerDto input);
    }
}
