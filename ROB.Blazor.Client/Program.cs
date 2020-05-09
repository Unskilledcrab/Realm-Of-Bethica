using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ROB.Blazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {


            //AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");            
            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(@"https://localhost:44374/") });

            await builder.Build().RunAsync();

        }
    }
}
