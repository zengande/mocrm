using Volo.Abp.Modularity;

namespace YunStorm.MoCRM.Customer
{
    [DependsOn(
        typeof(MoCRMCustomerDomainSharedModule)
        )]
    public class MoCRMCustomerDomainModule :
        AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}
