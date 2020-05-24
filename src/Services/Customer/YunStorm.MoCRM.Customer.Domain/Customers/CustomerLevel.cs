using System;
using System.Collections.Generic;
using System.Text;
using YunStorm.MoCRM.BuildingBlocks.Common;

namespace YunStorm.MoCRM.Customer.Customers
{
    public class CustomerLevel :
        Enumeration
    {
        public static CustomerLevel Key = new CustomerLevel(1, nameof(Key).ToUpper(), "重点客户");
        public static CustomerLevel General = new CustomerLevel(2, nameof(General).ToUpper(), "一般客户");

        protected CustomerLevel()
        {
        }

        public CustomerLevel(int id, string name)
            : base(id, name)
        {
        }

        public CustomerLevel(int id, string name, string displayName) : base(id, name, displayName)
        {
        }

        public static IEnumerable<CustomerLevel> List() =>
            new[] { Key, General };
    }
}
