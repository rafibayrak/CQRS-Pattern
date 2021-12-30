using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CQRS.SSO.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private string MyCorsName = "MyCors";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
#if DEBUG
            services.AddCors(cors =>
            {
                cors.AddPolicy(MyCorsName, policy =>
                {
                    policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
#endif

            services.AddDataProtection()
               //.SetDefaultKeyLifetime(TimeSpan.FromDays(14))
               .UseCustomCryptographicAlgorithms(
                 new ManagedAuthenticatedEncryptorConfiguration()
                 {
                     // A type that subclasses SymmetricAlgorithm
                     EncryptionAlgorithmType = typeof(Aes),

                     // Specified in bits
                     EncryptionAlgorithmKeySize = 256,

                     // A type that subclasses KeyedHashAlgorithm
                     ValidationAlgorithmType = typeof(HMACSHA256)
                 })
                .SetApplicationName("SharedCookieApp");
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                    {
                        options.Cookie.Domain = "localhost";
                        options.Cookie.Name = "SharedCookieApp";
                        options.Cookie.SameSite = SameSiteMode.Lax;
                        options.Cookie.Path = "/";
                        options.Cookie.IsEssential = true;
                        options.LoginPath = "/login";
                        options.Events = new CookieAuthenticationEvents()
                        {
                            OnRedirectToLogin = (context) =>
                            {
                                context.HttpContext.Response.Redirect(context.RedirectUri.Replace("https://localhost:44379/", "http://localhost:4200/"));
                                return Task.CompletedTask;
                            }
                        };
                        options.ExpireTimeSpan = TimeSpan.FromMinutes(120);

                    });
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "WebInterface";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
#if DEBUG
            app.UseCors(MyCorsName);
#endif
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "WebInterface";
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
