using CQRS.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Cryptography;

namespace CQRS.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddCustomSsoAuthenticatonConfig(this IServiceCollection services, string cookieName)
        {
            services.AddDataProtection().UseCustomCryptographicAlgorithms(new ManagedAuthenticatedEncryptorConfiguration()
            {
                EncryptionAlgorithmType = typeof(Aes),
                EncryptionAlgorithmKeySize = 256,
                ValidationAlgorithmType = typeof(HMACSHA256)
            }).SetApplicationName(cookieName);
        }

        public static void AddCustomCookieAuthentication(this IServiceCollection services, string cookieName)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = cookieName;
                    options.Cookie.SameSite = SameSiteMode.Lax;
                    options.Cookie.Path = "/";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(12);
                    options.Cookie.IsEssential = false;
                    options.LoginPath = "/login";
                    options.Events = new CookieAuthenticationEvents()
                    {
                        OnRedirectToLogin = async (context) =>
                        {
                            context.Response.StatusCode = 401;
                            await context.HttpContext.Response.WriteAsync("Token Validation Has Failed. Request Access Denied");
                            //return Task.CompletedTask;
                        }
                    };
                });
        }

        public static void AddCustomSqlServer(this IServiceCollection services, string sqlServerConnectionString, string migrationsPath)
        {
            services.AddDbContext<MediatorDataContext>(options =>
            {
                options.UseSqlServer(sqlServerConnectionString, o =>
                {
                    o.MigrationsAssembly(migrationsPath);
                });
            });
        }

        public static void AddCustomCors(this IServiceCollection services, string corsName, params string[] origins)
        {
            services.AddCors(cors =>
             {
                 cors.AddPolicy(corsName, policy =>
                 {
                     policy.WithOrigins(origins).AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                 });
             });
        }
    }
}
