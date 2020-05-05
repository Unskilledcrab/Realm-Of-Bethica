using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ROB.Web.Areas.Identity.IdentityHostingStartup))]
namespace ROB.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}