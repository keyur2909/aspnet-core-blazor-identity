using System;
using aspnet_core_blazor_identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(aspnet_core_blazor_identity.Areas.Identity.IdentityHostingStartup))]
namespace aspnet_core_blazor_identity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<aspnet_core_blazor_identityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("aspnet_core_blazor_identityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<aspnet_core_blazor_identityContext>();
            });
        }
    }
}