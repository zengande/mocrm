using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace YunStorm.MoCRM.Data
{
    /* This is used if database provider does't define
     * IMoCRMDbSchemaMigrator implementation.
     */
    public class NullMoCRMDbSchemaMigrator : IMoCRMDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}