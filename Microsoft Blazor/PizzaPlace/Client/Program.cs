using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Services;
using Microsoft.Extensions.DependencyInjection;
using PizzaPlace.Client;
using PizzaPlace.Client.Services;
using PizzaPlace.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaPlace.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddScoped<LazyAssemblyLoader>();
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
           

            builder.Services.AddTransient<IMenuService, MenuService>();
            builder.Services.AddTransient<IOrderService, OrderService>();
            builder.Services.AddSingleton<State>();

            await builder.Build().RunAsync();
        }
    }
}



