using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace YunStorm.MoCRM.Customer.EntityFrameworkCore
{
    [DependsOn(
        typeof(MoCRMCustomerEntityFrameworkCoreModule)
        )]
    public class MoCRMCustomerEntityFrameworkCoreDbMigrationsModule :
        AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MoCRMCustomerMigrationsDbContext>();
        }
    }
}
