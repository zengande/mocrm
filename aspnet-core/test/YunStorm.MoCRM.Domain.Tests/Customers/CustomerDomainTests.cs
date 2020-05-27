using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace YunStorm.MoCRM.Customers
{
    public class CustomerDomainTests : MoCRMDomainTestBase
    {
        private readonly IRepository<Customer, long> _customerRepository;
        public CustomerDomainTests()
        {
            _customerRepository = GetRequiredService<IRepository<Customer, long>>();
        }

        [Fact]
        public async Task Add_Contact_To_Customer_Successed()
        {
            var customer = new Customer("fake customer", "13000000000", "fakecustomer@mocrm.com");
            customer.AddContact("fake contact", "IT", "Developer", "15000000000", "fakecontact@mocrm.com", 1);

            var result = await _customerRepository.InsertAsync(customer, true);

            Assert.NotEmpty(customer.Contacts);
            Assert.True(result.Id > 0);
        }
    }
}
