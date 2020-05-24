using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace YunStorm.MoCRM.Customer.EntityFrameworkCore
{
    public class MoCRMCustomerMigrationsDbContextFactory :
        IDesignTimeDbContextFactory<MoCRMCustomerMigrationsDbContext>
    {
        public MoCRMCustomerMigrationsDbContext CreateDbContext(string[] args)
        {
            MoCRMCustomerEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<MoCRMCustomerMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"));

            return new MoCRMCustomerMigrationsDbContext(builder.Options);
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
