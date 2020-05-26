using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace YunStorm.MoCRM.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(MoCRMHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class MoCRMConsoleApiClientModule : AbpModule
    {
        
    }
}
