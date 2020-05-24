using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace YunStorm.MoCRM.Customer.EntityFrameworkCore
{
    [DependsOn(
        typeof(MoCRMCustomerDomainModule)
        )]
    public class MoCRMCustomerEntityFrameworkCoreModule :
        AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MoCRMCustomerDbContext>(options =>
            {
                //options.AddDefaultRepositories(includeAllEntities: false);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseMySQL();
            });
        }
    }
}
