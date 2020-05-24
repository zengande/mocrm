using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace YunStorm.MoCRM.Customer
{
    [DependsOn(
        typeof(MoCRMCustomerDomainModule),
        typeof(MoCRMCustomerApplicationContractsModule)
        )]
    public class MoCRMCustomerApplicationModule :
        AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Console.WriteLine("application module");
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<MoCRMCustomerApplicationModule>();
            });
        }
    }
}
