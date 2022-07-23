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
        public IList<string> GetListOfCitiesAsync()
        {
            var result = new List<string>();
            var url = Constants.API_URL + Constants.GET_CITIES_METHOD;
            var client = new RestClient(url)
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
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
            return result;
        }

        public StringBuilder GetListOfCitiesAsyncForOutput()
        {
            var cities = GetListOfCitiesAsync();
            var sb = new StringBuilder();
            foreach (var c in cities)
            {
                sb.AppendLine(c);
            }
            return sb;
        }
    }
}
