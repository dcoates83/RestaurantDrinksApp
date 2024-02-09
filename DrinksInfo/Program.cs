using DrinksInfo.Models;
using System.Net.Http.Headers;


namespace DrinksInfo
{
    internal class Program
    {
        private const string URL = "https://www.thecocktaildb.com/api/json/v1/1/list.php";
        private static readonly string urlParameters = "?c=list";
        // Entry point of the console application, could initialize the CategoriesMenu

        private static void Main(string[] args)
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response);
                //// Parse the response body.
                IEnumerable<CategoryModel> dataObjects = response.Content.ReadAsAsync<IEnumerable<CategoryModel>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                foreach (CategoryModel d in dataObjects)
                {
                    Console.WriteLine("{0}", d.StrCategory);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
        }
    }

}
