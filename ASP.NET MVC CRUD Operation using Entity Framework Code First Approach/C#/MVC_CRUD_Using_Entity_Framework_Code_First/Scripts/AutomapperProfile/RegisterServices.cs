using Bushel.Idserver.Management.Controllers;
using Bushel.Idserver.Management.Utility.AutomapperProfile;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Bushel.Idserver.Management
{
    public static class RegisterServices
    {
        public static IServiceCollection AddIdServerManagement(
            this IServiceCollection services)
        {
            var assembly = typeof(ClientController).GetTypeInfo().Assembly;

            // This will add the assembly as an application part. ASP.NET Core will then find controllers within it.
            services.AddMvc()
                    .AddApplicationPart(assembly);
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(
                    new EmbeddedFileProvider(typeof(ClientController).GetTypeInfo().Assembly));
            });
			var config = new AutoMapper.MapperConfiguration(c => c.AddProfile(new ApplicationProfile()));
			var mapper = config.CreateMapper();
			services.AddSingleton(mapper);
            return services;
        }
    }
} 
