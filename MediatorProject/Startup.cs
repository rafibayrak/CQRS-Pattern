using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Autofac;
using MediatorProject.Business.Dependencies;
using MediatorProject.CommandHandlers;
using MediatorProject.Extensions;
using MediatorProject.Model.Core;
using MediatorProject.Data;
using Microsoft.EntityFrameworkCore;

namespace MediatorProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }
        private string MyCorsName = "MyCors";
        private string SpaRootPath = "WebInterface";
        private string ProjectConfigInsideAppSettings = "ProjectConfig";

        public void ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                         .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                         .AddJsonFile("appsettings.json").Build();
            var section = config.GetSection(nameof(ProjectConfig));
            var projectSetting = section.Get<ProjectConfig>();
            services.Configure<ProjectConfig>(Configuration.GetSection(ProjectConfigInsideAppSettings));
            services.AddCustomSsoAuthenticatonConfig(projectSetting.CookieName);
#if DEBUG
            services.AddCustomCors(MyCorsName, projectSetting.CorsUrls);
#endif
            services.AddCustomCookieAuthentication(projectSetting.CookieName);
            services.AddControllers();
            services.AddCustomSqlServer(projectSetting.SqlServerConnectionString, "MediatorProject.Data");
            services.AddOptions();
            services.AddAutoMapper(typeof(DefineCommandHandler));
            services.AddCustomSpaStaticFiles(SpaRootPath);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
#if DEBUG
            app.UseCors(MyCorsName);
#endif
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.AddCustomUseSpa(SpaRootPath);
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<MediatorDataContext>();
                if (context.Database.IsSqlServer())
                {
                    scope.ServiceProvider.GetRequiredService<MediatorDataContext>().Database.Migrate();
                }
            }
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DependencyRegister());
        }
    }
}
