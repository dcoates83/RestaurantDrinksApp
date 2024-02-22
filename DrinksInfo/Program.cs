using DrinksInfo.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DrinksInfo
{
    internal class Program
    {


        private static void Main(string[] args)
        {

            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            _ = builder.Services.AddHttpClient();
            _ = builder.Services.AddTransient<CategoriesService>();

            using IHost host = builder.Build();

            CategoriesService categoriesService = host.Services.GetRequiredService<CategoriesService>();
            categoriesService.GetCategoriesAsync().Wait();


        }


    }

}
