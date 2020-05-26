using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YunStorm.MoCRM.Data;
using Volo.Abp.DependencyInjection;

namespace YunStorm.MoCRM.EntityFrameworkCore
{
    public class EntityFrameworkCoreMoCRMDbSchemaMigrator
        : IMoCRMDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreMoCRMDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the MoCRMMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<MoCRMMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}