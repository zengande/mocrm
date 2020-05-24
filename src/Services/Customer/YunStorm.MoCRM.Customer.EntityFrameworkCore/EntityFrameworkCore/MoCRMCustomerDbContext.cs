using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore;

namespace YunStorm.MoCRM.Customer.EntityFrameworkCore
{
    using YunStorm.MoCRM.Customer.Customers;
    public class MoCRMCustomerDbContext :
        AbpDbContext<MoCRMCustomerDbContext>
    {
        public const string DbTablePrefix = "app";
        public const string DbSchema = null;

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerLevel> CustomerLevels { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactRole> ContactRoles { get; set; }

        public MoCRMCustomerDbContext(DbContextOptions<MoCRMCustomerDbContext> options)
            : base(options)
        {
        }
    }
}
