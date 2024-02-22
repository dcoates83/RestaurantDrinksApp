using DrinksInfo.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace DrinksInfo.Services
{
    public class CategoryResponse
    {
        public List<CategoryModel> Drinks { get; set; } = [];
    }

    public class CategoriesService(
        IHttpClientFactory httpClientFactory,
        ILogger<CategoriesService> logger)
    {

        private const string URL = "https://www.thecocktaildb.com/api/json/v1/1/list.php";
        private static readonly string urlParameters = "?c=list";
        public async Task<CategoryModel[]?> GetCategoriesAsync()
        {

            using HttpClient client = httpClientFactory.CreateClient();

            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{URL}{urlParameters}");
                _ = response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {

                    CategoryResponse? categoryResponse = await response.Content.ReadFromJsonAsync<CategoryResponse>();
                    List<CategoryModel>? categories = categoryResponse?.Drinks;
                    return categories?.ToArray();
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return [];
        }
    }
}
