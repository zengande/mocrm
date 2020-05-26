using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace YunStorm.MoCRM.EntityFrameworkCore
{
    [DependsOn(
        typeof(MoCRMEntityFrameworkCoreModule)
        )]
    public class MoCRMEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MoCRMMigrationsDbContext>();
        }
    }
}
