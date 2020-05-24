using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace YunStorm.MoCRM.Customer
{
    public class MoCRMCustomerDomainSharedModule :
        AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(config =>
            {
                config.FileSets.AddEmbedded<MoCRMCustomerDomainSharedModule>("YunStorm.MoCRM.Customer");
            });
        }
    }
}
