using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore;

namespace YunStorm.MoCRM.Customer.EntityFrameworkCore
{
    public class MoCRMCustomerMigrationsDbContext :
        AbpDbContext<MoCRMCustomerMigrationsDbContext>
    {
        public MoCRMCustomerMigrationsDbContext(DbContextOptions<MoCRMCustomerMigrationsDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigureCustomerModels();
        }
    }
}
