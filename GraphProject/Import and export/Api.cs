using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace GraphProject
{
    public class Api
    {
        public async Task<Stock> OneStockDataFromApi(string stockName)
        {
            var _httpString = "https://financialmodelingprep.com/api/v3/historical-price-full/" + stockName +
                "?serietype=line&serieformat=array";

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), _httpString))
                {
                    request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");

                    var response = await httpClient.SendAsync(request);
                    string json = response.Content.ReadAsStringAsync().Result;
                    // Stock class matches json structure
                    // Small or capital letters dont have to match between
                    // class properties and json properties
                    return JsonConvert.DeserializeObject<Stock>(json);
                }
            }
        }
    }
}
