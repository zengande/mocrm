using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace YunStorm.MoCRM.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class MoCRMMigrationsDbContextFactory : IDesignTimeDbContextFactory<MoCRMMigrationsDbContext>
    {
        public MoCRMMigrationsDbContext CreateDbContext(string[] args)
        {
            MoCRMEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<MoCRMMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"));

            return new MoCRMMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
