using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using YunStorm.MoCRM.ContractOrdering.Application;
using Microsoft.OpenApi.Models;
using YunStorm.MoCRM.ContractOrdering.API.Filters;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using YunStorm.MoCRM.ContractOrdering.API.Swagger;

namespace YunStorm.MoCRM.ContractOrdering.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

            var identityUrl = "http://localhost:3999";

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = identityUrl;
                options.RequireHttpsMetadata = false;
                options.Audience = "contractorders";
            });

            services.AddApplicationServices();

            services.AddControllers(options=> {
                options.Filters.Add<ApiExceptionFilter>();
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MoCRM - Contract Ordering HTTP API",
                    Version = "v1",
                    Description = "The Contract Ordering Service HTTP API"
                });
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl = new Uri("http://localhost:3999/connect/authorize"),
                            TokenUrl = new Uri($"http://localhost:3999/connect/token"),
                            Scopes = new Dictionary<string, string>()
                            {
                                { "contractorders", "Contract Ordering API" }
                            }
                        }
                    }
                });
                options.OperationFilter<AuthorizeCheckOperationFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"/swagger/v1/swagger.json", "Contract Ordering.API V1");
                    c.OAuthClientId("contractorderingswaggerui");
                    c.OAuthAppName("Contract Ordering Swagger UI");
                });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
