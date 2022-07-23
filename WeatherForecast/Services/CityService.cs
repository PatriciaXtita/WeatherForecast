using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Services
{
    public class CityService : ICityService
    {
        public async Task<IList<string>> GetListOfCitiesAsync()
        {
            var result = new List<string>();

            try
            {

                var client = new RestClient("https://sandbox.musement.com/api/v3/cities");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = await client.ExecuteAsync(request);
                if (response.IsSuccessful && response.Content != null)
                {
                    var list = JArray.Parse(response.Content);
                    foreach (var item in list)
                    {
                        var name = item["name"];
                        if (name != null)
                        {
                            result.Add(name.ToString());
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public async Task<StringBuilder> GetListOfCitiesAsyncForOutput()
        {
            var cities = await GetListOfCitiesAsync();
            var sb = new StringBuilder();
            foreach (var c in cities)
            {
                sb.AppendLine(c);
            }
            return sb;
        }
    }
}
