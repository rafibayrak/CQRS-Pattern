using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Extensions
{
    public static class SpaExtensions
    {
        public static void AddCustomSpaStaticFiles(this IServiceCollection services, string spaRootPath)
        {
            services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = spaRootPath;
            });
        }

        public static void AddCustomUseSpa(this IApplicationBuilder app, string spaRootPath)
        {
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = spaRootPath;
            });
        }
    }
}
