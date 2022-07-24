using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Services
{
    public class WeatherService : IWeatherService
    {

        private readonly ICityService _cityService;

        public WeatherService
            (ICityService cityService)
        {
            _cityService = cityService;
        }

        public StringBuilder GetWeatherForecast(int days = 2)
        {
            StringBuilder sb = new StringBuilder();
            var cities = _cityService.GetListOfCitiesAsync();
            if (days <= 0)
            {
                sb.AppendLine("Invalid number of days selected");
                return sb;
            }
            foreach (var c in cities)
            {
                string cityWeather = c + " |";
                int day = 1;
                while (day <= days)
                {
                    var weather = GetWeatherOfCityForDay(c, day);
                    if (day == 1)
                    {
                        cityWeather += " " + weather;
                    }
                    else
                    {
                        cityWeather += " - " + weather;
                    }
                    day++;
                }
                sb.AppendLine(cityWeather);
            }
            return sb;
        }

        public string GetWeatherOfCityForDay(string city, int day)
        {
            string result = "no data";
            var url = Constants.WEATHER_API_URL + Constants.WEATHER_API_METHOD + "?key=" +
                Constants.WEATHER_API_KEY + "&q=" + city + "&days=" + day + "&aqi=no&alerts=no";
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var list = JObject.Parse(response.Content);
            if (list["error"] != null)
            {
                return "location not found on weather api";
            }
            var weather = list["forecast"]["forecastday"].First["day"]["condition"]["text"];
            if (weather != null)
            {
                return weather.ToString();
            }
            return result;
        }
    }
}
