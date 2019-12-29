using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KocFinans.CreditCalculation.Common;
using KocFinans.CreditCalculation.Data;
using KocFinans.CreditCalculation.Data.Model;
using KocFinans.CreditCalculation.Data.Repository;
using KocFinans.CreditCalculation.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace KocFinans.CreditCalculation
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<CreditCalculationDBContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:CreditCalculationDB"]));
            services.AddScoped<IDataRepository<CustomerCreditInfo>, DataRepository<CustomerCreditInfo>>();
            services.AddScoped<IRuleEngine, RuleEngine>();
            services.AddScoped<IIntegrationServiceLayer, IntegrationServiceLayer>();
            services.AddScoped<ISenderNotification, SenderNotification>();
            services.Configure<CreditEndpointSettings>(Configuration.GetSection("CreditEndpointSettings"));
            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info { Title = "Kredi Hesaplama Servisi", Version = "v1", Description = "KoçFinans - Kredi Hesaplama Servisi" });
                c.DescribeAllEnumsAsStrings();
                c.DescribeStringEnumsInCamelCase();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kredi Hesaplama Servisi");
                c.RoutePrefix = string.Empty;
                c.DocumentTitle = "Kredi Hesaplama Servisi";
                c.EnableFilter();
                c.DefaultModelsExpandDepth(2);
                c.DisplayRequestDuration();
                c.DefaultModelRendering(ModelRendering.Example);
                c.DisplayOperationId();
            });
            var settings = Configuration.GetSection("CreditEndpointSettings").Get<CreditEndpointSettings>();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
