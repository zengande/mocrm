using YunStorm.MoCRM.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace YunStorm.MoCRM
{
    [DependsOn(
        typeof(MoCRMEntityFrameworkCoreTestModule)
        )]
    public class MoCRMDomainTestModule : AbpModule
    {

    }
}