using System;
using System.Collections.Generic;
using System.Text;

namespace YunStorm.MoCRM.Customers
{
    public class CreateCustomerDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string WebSite { get; set; }
        public string Remarks { get; set; }
    }
}
