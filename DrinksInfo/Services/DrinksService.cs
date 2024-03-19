using DrinksInfo.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace DrinksInfo.Services
{

    public class DrinksResponse
    {
        public List<DrinksModel> Drinks { get; set; } = [];
    }

    public class DrinksService(
               IHttpClientFactory httpClientFactory,
        ILogger<CategoriesService> logger)
    {
        private const string URL = "https://www.thecocktaildb.com/api/json/v1/1/filter.php";


        public async Task<DrinksModel[]?> GetDrinksAsync(string drink)
        {
            using HttpClient client = httpClientFactory.CreateClient();

            try
            {
                using HttpResponseMessage response = await client.GetAsync($"{URL}?c={drink}");
                _ = response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {

                    DrinksResponse? drinksResponse = await response.Content.ReadFromJsonAsync<DrinksResponse>();
                    List<DrinksModel>? drinks = drinksResponse?.Drinks;
                    return drinks?.ToArray();
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

