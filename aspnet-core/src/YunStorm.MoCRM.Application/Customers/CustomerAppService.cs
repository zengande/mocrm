using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace YunStorm.MoCRM.Customers
{
    public class CustomerAppService : MoCRMAppService, ICustomerAppService
    {
        private readonly IRepository<Customer, long> _customerRepository;
        public CustomerAppService(IRepository<Customer, long> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task CreateAsync(CreateCustomerDto input)
        {
            var customer = ObjectMapper.Map<CreateCustomerDto, Customer>(input);
            await _customerRepository.InsertAsync(customer, true);
        }
    }
}
