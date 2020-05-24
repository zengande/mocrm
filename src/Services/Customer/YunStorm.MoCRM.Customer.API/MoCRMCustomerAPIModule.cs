using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using YunStorm.MoCRM.Customer.EntityFrameworkCore;

namespace YunStorm.MoCRM.Customer
{
    [DependsOn(
        typeof(MoCRMCustomerApplicationModule),
        typeof(MoCRMCustomerEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAspNetCoreMvcModule)
        )]
    public class MoCRMCustomerAPIModule :
        AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();
            ConfigureVirtualFileSystem(hostingEnvironment);
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseConfiguredEndpoints();
        }

        private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<MoCRMCustomerDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}YunStorm.MoCRM.Customer.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<MoCRMCustomerDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}YunStorm.MoCRM.Customer.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<MoCRMCustomerApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}YunStorm.MoCRM.Customer.Application.Contracts"));
                    options.FileSets.ReplaceEmbeddedByPhysical<MoCRMCustomerApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}YunStorm.MoCRM.Customer.Application"));
                    options.FileSets.ReplaceEmbeddedByPhysical<MoCRMCustomerAPIModule>(hostingEnvironment.ContentRootPath);
                });
            }
        }
    }
}
