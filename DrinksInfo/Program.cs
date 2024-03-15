using DrinksInfo.Menus;
using DrinksInfo.Models;
using DrinksInfo.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DrinksInfo
{
    internal class Program
    {


        private static async Task Main(string[] args)
        {

            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            _ = builder.Services.AddHttpClient();
            _ = builder.Services.AddTransient<CategoriesService>();

            using IHost host = builder.Build();

            CategoriesService categoriesService = host.Services.GetRequiredService<CategoriesService>();
            CategoryModel[]? drinkCategories = await categoriesService.GetCategoriesAsync();

            while (drinkCategories is not null)
            {
                CategoriesMenu.DisplayCategoriesMenu(drinkCategories);
                Console.WriteLine("Enter the name of the category you want to see the drinks for: ");
                string? resp = Console.ReadLine();
                if (resp is not null)
                {
                    DrinksService drinksService = host.Services.GetRequiredService<DrinksService>();
                    DrinksModel[]? drinks = await drinksService.GetDrinksAsync(resp);
                    DrinksMenu.DisplayDrinksMenu(drinks);
                }


            }

        }


    }

}
