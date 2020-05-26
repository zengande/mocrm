using YunStorm.MoCRM.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace YunStorm.MoCRM.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(MoCRMEntityFrameworkCoreDbMigrationsModule),
        typeof(MoCRMApplicationContractsModule)
        )]
    public class MoCRMDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
