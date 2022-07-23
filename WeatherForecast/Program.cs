using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecast;
using WeatherForecast.Services;

class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        services
            .AddSingleton<Executor, Executor>()
            .BuildServiceProvider()
            .GetService<Executor>()
            .ExecuteAsync();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        //Services
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<IWeatherService, WeatherService>();
    }
}

