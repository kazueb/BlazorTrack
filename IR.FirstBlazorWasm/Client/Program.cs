using MatBlazor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IR.FirstBlazorWasm.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddMsalAuthentication(options =>
            {
                builder.Configuration.Bind("Azure:Security", options.ProviderOptions.Authentication);
                options.ProviderOptions.DefaultAccessTokenScopes.Add("https://graph.microsoft.com/User.Read"); // read scope link "https:// /User.Read
                options.ProviderOptions.LoginMode = "redirect";
            });
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.ConfigureServices();

            await builder.Build().RunAsync();
        }
    }

    public static class ConfigurationExtensions
    {
        public static void ConfigureServices(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddMatBlazor();
        }
    }
}
