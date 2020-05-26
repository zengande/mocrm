using Volo.Abp.Modularity;

namespace YunStorm.MoCRM
{
    [DependsOn(
        typeof(MoCRMApplicationModule),
        typeof(MoCRMDomainTestModule)
        )]
    public class MoCRMApplicationTestModule : AbpModule
    {

    }
}