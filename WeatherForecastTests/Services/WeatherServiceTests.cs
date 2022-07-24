using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherForecast.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Services.Tests
{
    [TestClass]
    public class WeatherServiceTests
    {
        [TestMethod]
        public void GetWeatherForecastWithoutParameters()
        {
            var cityService = new CityService();
            var weatherService = new WeatherService(cityService);
            var result = weatherService.GetWeatherForecast();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StringBuilder));
        }

        [TestMethod]
        public void GetWeatherForecastWithParameters()
        {
            var cityService = new CityService();
            var weatherService = new WeatherService(cityService);
            var result = weatherService.GetWeatherForecast(3);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StringBuilder));
        }


        [TestMethod]
        public void GetWeatherOfCityForDay()
        {
            var cityService = new CityService();
            var weatherService = new WeatherService(cityService);
            var result = weatherService.GetWeatherOfCityForDay("amsterdam", 1);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(string));
        }
    }
}