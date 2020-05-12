using MediatR;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using YunStorm.MoCRM.BuildingBlocks.Application.Behaviours;
using YunStorm.MoCRM.BuildingBlocks.Application.Interfaces;
using YunStorm.MoCRM.ContractOrdering.Application.Services;

namespace YunStorm.MoCRM.ContractOrdering.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddValidatorsFromAssembly(assembly);
            services.AddMediatR(assembly);

            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            return services;
        }
    }
}
