using DrinksInfo.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Text.Json;

namespace DrinksInfo.Services
{

    public class CategoriesService(
        IHttpClientFactory httpClientFactory,
        ILogger<CategoriesService> logger)
    {

        private const string URL = "https://www.thecocktaildb.com/api/json/v1/1/list.php";
        private static readonly string urlParameters = "?c=list";
        public async Task<CategoryModel[]> GetCategoriesAsync()
        {
            // Create the client
            using HttpClient client = httpClientFactory.CreateClient();

            try
            {
                // Make HTTP GET request
                // Parse JSON response deserialize into Todo types
                CategoryModel[]? categories = await client.GetFromJsonAsync<CategoryModel[]>(
                    $"{URL}{urlParameters}",
                    new JsonSerializerOptions(JsonSerializerDefaults.Web));

                return categories ?? [];
            }
            catch (Exception ex)
            {
                logger.LogError("Error getting something fun to say: {Error}", ex);
            }

            return [];
        }
    }
}
