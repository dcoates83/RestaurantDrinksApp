using Microsoft.Extensions.Logging;

namespace DrinksInfo.Services
{
    internal class DrinksService
    {
        public DrinksService(
               IHttpClientFactory httpClientFactory,
        ILogger<CategoriesService> logger)
        {

        }
    }
}
