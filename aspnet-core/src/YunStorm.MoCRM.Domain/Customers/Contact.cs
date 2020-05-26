using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace YunStorm.MoCRM.Customers
{
    public class Contact : Entity<long>
    {
        public long CustomerId { get; protected set; }
    }
}
