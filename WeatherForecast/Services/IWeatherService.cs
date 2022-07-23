using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Services
{
    public interface IWeatherService
    {
        //Added this "days" property so if we ever want to extend or let customize the weather forecast we can
        StringBuilder GetWeatherForecast(int days = 2);
    }
}
