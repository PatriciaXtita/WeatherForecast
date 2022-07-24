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
    public class CityServiceTests
    {
        [TestMethod]
        public void GetListOfCitiesAsyncTest()
        {
            var cityService = new CityService();
            var result = cityService.GetListOfCitiesAsync();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.First(), typeof(string));
        }


        [TestMethod]
        public void GetListOfCitiesAsyncForOutput()
        {
            var cityService = new CityService();
            var result = cityService.GetListOfCitiesAsyncForOutput();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StringBuilder));
        }
    }
}