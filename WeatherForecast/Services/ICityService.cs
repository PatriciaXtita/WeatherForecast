using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Services
{
    public interface ICityService
    {
        Task<IList<string>> GetListOfCitiesAsync();
        Task<StringBuilder> GetListOfCitiesAsyncForOutput();
    }
}
